namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUniversity;
        private System.Windows.Forms.TextBox txtUniversity;
        private System.Windows.Forms.Label lblPostCount;
        private System.Windows.Forms.NumericUpDown numPostCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox lstTitles;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtKeywords;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUniversity = new System.Windows.Forms.Label();
            this.txtUniversity = new System.Windows.Forms.TextBox();
            this.lblPostCount = new System.Windows.Forms.Label();
            this.numPostCount = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lstTitles = new System.Windows.Forms.ListBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPostCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUniversity
            // 
            this.lblUniversity.AutoSize = true;
            this.lblUniversity.Location = new System.Drawing.Point(30, 25);
            this.lblUniversity.Name = "lblUniversity";
            this.lblUniversity.Size = new System.Drawing.Size(82, 24);
            this.lblUniversity.TabIndex = 0;
            this.lblUniversity.Text = "大学名称：";
            // 
            // txtUniversity
            // 
            this.txtUniversity.Location = new System.Drawing.Point(120, 22);
            this.txtUniversity.Name = "txtUniversity";
            this.txtUniversity.Size = new System.Drawing.Size(200, 29);
            this.txtUniversity.TabIndex = 1;
            // 
            // lblPostCount
            // 
            this.lblPostCount.AutoSize = true;
            this.lblPostCount.Location = new System.Drawing.Point(350, 25);
            this.lblPostCount.Name = "lblPostCount";
            this.lblPostCount.Size = new System.Drawing.Size(106, 24);
            this.lblPostCount.TabIndex = 2;
            this.lblPostCount.Text = "帖子数量：";
            // 
            // numPostCount
            // 
            this.numPostCount.Location = new System.Drawing.Point(460, 22);
            this.numPostCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numPostCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPostCount.Name = "numPostCount";
            this.numPostCount.Size = new System.Drawing.Size(80, 29);
            this.numPostCount.TabIndex = 3;
            this.numPostCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(570, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 32);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始爬取";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 65);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(640, 23);
            this.progressBar.TabIndex = 5;
            // 
            // lstTitles
            // 
            this.lstTitles.FormattingEnabled = true;
            this.lstTitles.ItemHeight = 24;
            this.lstTitles.Location = new System.Drawing.Point(30, 100);
            this.lstTitles.Name = "lstTitles";
            this.lstTitles.Size = new System.Drawing.Size(350, 292);
            this.lstTitles.TabIndex = 6;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(400, 100);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(130, 24);
            this.lblKeywords.TabIndex = 7;
            this.lblKeywords.Text = "高频词及频率：";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(400, 130);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ReadOnly = true;
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeywords.Size = new System.Drawing.Size(270, 262);
            this.txtKeywords.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.lblUniversity);
            this.Controls.Add(this.txtUniversity);
            this.Controls.Add(this.lblPostCount);
            this.Controls.Add(this.numPostCount);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lstTitles);
            this.Controls.Add(this.lblKeywords);
            this.Controls.Add(this.txtKeywords);
            this.Name = "Form1";
            this.Text = "大学贴吧爬虫";
            ((System.ComponentModel.ISupportInitialize)(this.numPostCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
