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
            dataGridView2 = new DataGridView();
            btnReset = new Button();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            btnCompare = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            txtTiebaName.TextChanged += txtTiebaName_TextChanged;
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
            dataGridView1.Location = new Point(744, 144);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(626, 393);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(31, 144);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(700, 393);
            dataGridView2.TabIndex = 5;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(827, 27);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(112, 34);
            btnReset.TabIndex = 6;
            btnReset.Text = "重置";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(31, 584);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(112, 30);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 557);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 8;
            label1.Text = "热词个数";
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(1000, 27);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(169, 34);
            btnCompare.TabIndex = 9;
            btnCompare.Text = "贴吧成分对比";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(686, 2);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 10;
            label2.Text = "爬取页数";
            label2.Click += label2_Click;
            // 
            // frmSpider
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 1002);
            Controls.Add(label2);
            Controls.Add(btnCompare);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(btnReset);
            Controls.Add(dataGridView2);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCrawl;
        private TextBox txtTiebaName;
        private ProgressBar progressBar1;
        private NumericUpDown numPages;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button btnReset;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button btnCompare;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var compareForm = new frmCompare();
            compareForm.ShowDialog();
        }
        private Label label2;
    }
}