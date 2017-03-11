namespace edmx_form
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.txtEdmxSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEdmxDes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXmlnsNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "生成";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库连接字符串：";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(293, 13);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(302, 75);
            this.txtConnStr.TabIndex = 2;
            this.txtConnStr.Text = "data source=60.205.94.121;initial catalog=HISSys;persist security info=True;user " +
    "id=sa;password=wgzx@123;";
            // 
            // txtEdmxSrc
            // 
            this.txtEdmxSrc.Location = new System.Drawing.Point(293, 94);
            this.txtEdmxSrc.Multiline = true;
            this.txtEdmxSrc.Name = "txtEdmxSrc";
            this.txtEdmxSrc.Size = new System.Drawing.Size(302, 49);
            this.txtEdmxSrc.TabIndex = 4;
            this.txtEdmxSrc.Text = "\\\\Mac\\Home\\Documents\\我的文件\\乱七八糟\\HIS\\SVN\\1. SOURCE\\HIS\\HIS\\Sephiroth.Ang.HIS.Entity" +
    "s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "源Edmx文件的物理路径：";
            // 
            // txtEdmxDes
            // 
            this.txtEdmxDes.Location = new System.Drawing.Point(293, 154);
            this.txtEdmxDes.Multiline = true;
            this.txtEdmxDes.Name = "txtEdmxDes";
            this.txtEdmxDes.Size = new System.Drawing.Size(302, 49);
            this.txtEdmxDes.TabIndex = 6;
            this.txtEdmxDes.Text = "\\\\Mac\\Home\\Documents\\我的文件\\乱七八糟\\HIS\\SVN\\1. SOURCE\\HIS\\HIS\\Sephiroth.Ang.HIS.Entity" +
    "s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "新生成Edmx文件的物理路径：";
            // 
            // txtXmlnsNameSpace
            // 
            this.txtXmlnsNameSpace.Location = new System.Drawing.Point(293, 217);
            this.txtXmlnsNameSpace.Multiline = true;
            this.txtXmlnsNameSpace.Name = "txtXmlnsNameSpace";
            this.txtXmlnsNameSpace.Size = new System.Drawing.Size(302, 63);
            this.txtXmlnsNameSpace.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Edmx中的xmlns命名空间（每个版本可能不一样）：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 421);
            this.Controls.Add(this.txtXmlnsNameSpace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEdmxDes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEdmxSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "Form1";
            this.Text = "EF映射添加注释工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.TextBox txtEdmxSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEdmxDes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXmlnsNameSpace;
        private System.Windows.Forms.Label label4;
    }
}

