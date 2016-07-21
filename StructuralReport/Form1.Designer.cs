namespace StructuralReport
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ReportXML reportLists;

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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.templatelistBox = new System.Windows.Forms.ListBox();
            this.TemplateListLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // templatelistBox
            // 
            this.templatelistBox.FormattingEnabled = true;
            this.templatelistBox.ItemHeight = 16;
            //this.templatelistBox.Items.AddRange(new object[] {
            //"CT Brain",
            //"MR Ankle"});
            this.templatelistBox.Location = new System.Drawing.Point(0, 49);
            this.templatelistBox.Margin = new System.Windows.Forms.Padding(4);
            this.templatelistBox.Name = "templatelistBox";
            this.templatelistBox.Size = new System.Drawing.Size(236, 660);
            this.templatelistBox.TabIndex = 0;
            // 
            // TemplateListLabel
            // 
            this.TemplateListLabel.AutoSize = true;
            this.TemplateListLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TemplateListLabel.Enabled = false;
            this.TemplateListLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TemplateListLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TemplateListLabel.Location = new System.Drawing.Point(4, 16);
            this.TemplateListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TemplateListLabel.Name = "TemplateListLabel";
            this.TemplateListLabel.Size = new System.Drawing.Size(74, 18);
            this.TemplateListLabel.TabIndex = 1;
            this.TemplateListLabel.Text = "模板列表";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(276, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 392);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TemplateListLabel);
            this.Controls.Add(this.templatelistBox);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "结构化报告";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox templatelistBox;
        private System.Windows.Forms.Label TemplateListLabel;
        private System.Windows.Forms.Panel panel1;
    }
}

