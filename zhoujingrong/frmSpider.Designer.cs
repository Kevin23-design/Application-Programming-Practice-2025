namespace choices
{
    partial class frmSpider
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
            btnCrawl = new Button();
            txtTiebaName = new TextBox();
            progressBar1 = new ProgressBar();
            numPages = new NumericUpDown();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCrawl
            // 
            btnCrawl.Location = new Point(543, 27);
            btnCrawl.Name = "btnCrawl";
            btnCrawl.Size = new Size(112, 34);
            btnCrawl.TabIndex = 0;
            btnCrawl.Text = "搜索";
            btnCrawl.UseVisualStyleBackColor = true;
            btnCrawl.Click += btnCrawl_Click;
            // 
            // txtTiebaName
            // 
            txtTiebaName.Location = new Point(31, 29);
            txtTiebaName.Name = "txtTiebaName";
            txtTiebaName.Size = new Size(483, 30);
            txtTiebaName.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(31, 78);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1380, 34);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // numPages
            // 
            numPages.Location = new Point(686, 29);
            numPages.Name = "numPages";
            numPages.Size = new Size(112, 30);
            numPages.TabIndex = 3;
            numPages.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPages.ValueChanged += numPages_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 137);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1380, 853);
            dataGridView1.TabIndex = 4;
            // 
            // frmSpider
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 1002);
            Controls.Add(dataGridView1);
            Controls.Add(numPages);
            Controls.Add(progressBar1);
            Controls.Add(txtTiebaName);
            Controls.Add(btnCrawl);
            Name = "frmSpider";
            Text = "百度贴吧极速版";
            Load += frmSpider_Load;
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCrawl;
        private TextBox txtTiebaName;
        private ProgressBar progressBar1;
        private NumericUpDown numPages;
        private DataGridView dataGridView1;
    }
}