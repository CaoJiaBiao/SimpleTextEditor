namespace SimpleTextEditor
{
    partial class AboutDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.lbVer = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.tbDes = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(24, 29);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(180, 15);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称：SimpleTextEditor";
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Location = new System.Drawing.Point(24, 61);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(68, 15);
            this.lbAuthor.TabIndex = 1;
            this.lbAuthor.Text = "作者：DL";
            // 
            // lbVer
            // 
            this.lbVer.AutoSize = true;
            this.lbVer.Location = new System.Drawing.Point(24, 95);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(84, 15);
            this.lbVer.TabIndex = 2;
            this.lbVer.Text = "版本：V1.0";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(27, 132);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(52, 15);
            this.lb.TabIndex = 3;
            this.lb.Text = "说明：";
            // 
            // tbDes
            // 
            this.tbDes.Location = new System.Drawing.Point(71, 132);
            this.tbDes.Multiline = true;
            this.tbDes.Name = "tbDes";
            this.tbDes.ReadOnly = true;
            this.tbDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDes.Size = new System.Drawing.Size(199, 72);
            this.tbDes.TabIndex = 4;
            this.tbDes.Text = "SimpleTextEditor,简单的文本编辑器";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(158, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AboutDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(278, 296);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbDes);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.lbVer);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.lbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.Load += new System.EventHandler(this.AboutDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Label lbVer;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox tbDes;
        private System.Windows.Forms.Button btnOK;
    }
}