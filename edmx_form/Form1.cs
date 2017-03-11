using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;

namespace edmx_form
{
    /// <summary>
    /// 2017年3月11日21:42:34 
    /// wzc
    /// 修正
    /// </summary>
    public partial class Form1 : Form
    {
        private NameValueCollection _AppSettings;
        /// <summary>AppSettings</summary>
        public NameValueCollection AppSettings { get { return _AppSettings ?? (_AppSettings = ConfigurationManager.AppSettings); } }

        private ConnectionStringSettingsCollection _ConnectionStrings;
        /// <summary>连接字符串设置</summary>
        public ConnectionStringSettingsCollection ConnectionStrings { get { return _ConnectionStrings ?? (_ConnectionStrings = ConfigurationManager.ConnectionStrings); } }

        public Form1()
        {
            InitializeComponent();
            if (AppSettings != null && AppSettings.Count > 0)
            {
                //txtEdmxSrc.Text = AppSettings["InputFileName"];
                //txtEdmxDes.Text = AppSettings["OutputFileName"];
                txtXmlnsNameSpace.Text = AppSettings["XmlnsNameSpaces"];
            }
            if (ConnectionStrings != null && ConnectionStrings.Count > 0)
            {
               // txtConnStr.Text = ConnectionStrings["ConnStr"] != null ? ConnectionStrings["ConnStr"].ConnectionString : null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String connStr = txtConnStr.Text.Trim();
            String inputFileName = txtEdmxSrc.Text.Trim();
            String outputFileName = txtEdmxDes.Text.Trim();
            String xmlnsNameSpace = txtXmlnsNameSpace.Text.Trim();
            if (String.IsNullOrEmpty(connStr))
            {
                MessageBox.Show("请填写数据库连接字符串！");
                return;
            }
            if (String.IsNullOrEmpty(inputFileName))
            {
                MessageBox.Show("请填写源Edmx文件的物理路径！");
                return;
            }
            if (String.IsNullOrEmpty(outputFileName))
            {
                MessageBox.Show("请填写新生成Edmx文件的物理路径！");
                return;
            }
            if (String.IsNullOrEmpty(xmlnsNameSpace))
            {
                MessageBox.Show("请填写Edmx中的xmlns命名空间（每个版本可能不一样）！");
                return;
            }
            try
            {
                var creater = new Creater(connStr, inputFileName, outputFileName, xmlnsNameSpace);
                creater.CreateDocumentation();
                creater.Dispose();
                MessageBox.Show("宾果，操作成功！");
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>修改数据库映射到EF edmx文件，为其添加数据库表、列注释</summary>
    public class Creater : IDisposable
    {
        private String _ConnStr;
        /// <summary>数据库连接字符串</summary>
        public String ConnStr { get { return _ConnStr; } set { _ConnStr = value; } }

        private String _InputFileName;
        /// <summary>输入文件（绝对路径）</summary>
        public String InputFileName { get { return _InputFileName; } set { _InputFileName = value; } }

        private String _OutputFileName;
        /// <summary>输出文件（绝对路径）</summary>
        public String OutputFileName { get { return _OutputFileName; } set { _OutputFileName = value; } }

        private SqlConnection _Conn;
        /// <summary>数据库连接</summary>
        public SqlConnection Conn { get { return _Conn; } set { _Conn = value; } }

        private String _XmlnsNameSpace;
        /// <summary>Xmlns命名空间</summary>
        public String XmlnsNameSpace { get { return _XmlnsNameSpace; } set { _XmlnsNameSpace = value; } }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="inputFileName"></param>
        /// <param name="outputFileName"></param>
        /// <param name="xmlnsNameSpace"></param>
        public Creater(String connStr, String inputFileName, String outputFileName, String xmlnsNameSpace)
        {
            ConnStr = connStr;
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            XmlnsNameSpace = xmlnsNameSpace;
            Conn = new SqlConnection(connStr);
        }

        public void Dispose()
        {
            Conn.Dispose();
        }
        /// <summary>创建注释文本</summary>
        public void CreateDocumentation()
        {
            Conn.Open();
            var doc = XDocument.Load(InputFileName);
            var entityTypeElements = doc.Descendants("{" + XmlnsNameSpace + "}EntityType");
            foreach (var entityTypeElement in entityTypeElements)
            {
                var tableName = entityTypeElement.Attribute("Name").Value;
                var propertyElements = entityTypeElement.Descendants("{" + XmlnsNameSpace + "}Property");
                AddNodeDocumentation(entityTypeElement, GetTableDocumentation(tableName));
                foreach (var propertyElement in propertyElements)
                {
                    var columnName = propertyElement.Attribute("Name").Value;
                    AddNodeDocumentation(propertyElement, GetColumnDocumentation(tableName, columnName));
                }
            }
            if (File.Exists(OutputFileName))
            {
                File.Delete(OutputFileName);
            }
            doc.Save(OutputFileName);
        }
        /// <summary>
        /// 给指定的Xml节点添加文档说明
        /// </summary>
        /// <param name="element"></param>
        /// <param name="documentation"></param>
        private void AddNodeDocumentation(XElement element, String documentation)
        {
            if (String.IsNullOrEmpty(documentation))
            {
                return;
            }
            element.Descendants("{" + XmlnsNameSpace + "}Documentation").Remove();
            element.AddFirst(new XElement("{" + XmlnsNameSpace + "}Documentation", new XElement("{" + XmlnsNameSpace + "}Summary", documentation)));
        }

        /// <summary>获取表文档描述</summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private String GetTableDocumentation(String tableName)
        {
            using (var command = new SqlCommand(@"SELECT [value] 
                                                          FROM fn_listextendedproperty (
                                                                'MS_Description', 
                                                                'schema', 'dbo', 
                                                                'table',  @TableName, 
                                                                null, null)", Conn))
            {
                command.Parameters.AddWithValue("@TableName", tableName);
                return command.ExecuteScalar() as String;
            }
        }
        /// <summary>
        /// 获取指定表的指定列文档描述
        /// </summary>
        /// <param name="tableName">指定表</param>
        /// <param name="columnName">指定列</param>
        /// <returns></returns>
        private String GetColumnDocumentation(String tableName, String columnName)
        {
            using (SqlCommand command = new SqlCommand(@"SELECT [value] 
                                                         FROM fn_listextendedproperty (
                                                                'MS_Description', 
                                                                'schema', 'dbo', 
                                                                'table', @TableName, 
                                                                'column', @columnName)", Conn))
            {

                command.Parameters.AddWithValue("TableName", tableName);
                command.Parameters.AddWithValue("ColumnName", columnName);

                return command.ExecuteScalar() as String;
            }
        }
    }
}
