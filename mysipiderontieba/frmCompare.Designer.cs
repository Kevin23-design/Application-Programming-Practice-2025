namespace choices
{
    partial class frmCompare
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTieba1;
        private TextBox txtTieba2;
        private Button btnStartCompare;
        private Label lblResult;
        private Label labelTieba1;
        private Label labelTieba2;
        private PictureBox pictureBoxThumb;
        private TextBox txtHotWord;
        private Label labelHotWord;

        private void InitializeComponent()
        {
            txtTieba1 = new TextBox();
            txtTieba2 = new TextBox();
            btnStartCompare = new Button();
            lblResult = new Label();
            labelTieba1 = new Label();
            labelTieba2 = new Label();
            pictureBoxThumb = new PictureBox();
            txtHotWord = new TextBox();
            labelHotWord = new Label();
            numPages = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            SuspendLayout();
            // 
            // txtTieba1
            // 
            txtTieba1.Location = new Point(130, 27);
            txtTieba1.Name = "txtTieba1";
            txtTieba1.Size = new Size(200, 30);
            txtTieba1.TabIndex = 1;
            // 
            // txtTieba2
            // 
            txtTieba2.Location = new Point(130, 77);
            txtTieba2.Name = "txtTieba2";
            txtTieba2.Size = new Size(200, 30);
            txtTieba2.TabIndex = 3;
            // 
            // btnStartCompare
            // 
            btnStartCompare.Location = new Point(30, 126);
            btnStartCompare.Name = "btnStartCompare";
            btnStartCompare.Size = new Size(120, 34);
            btnStartCompare.TabIndex = 4;
            btnStartCompare.Text = "开始对比";
            btnStartCompare.Click += btnStartCompare_Click;
            // 
            // lblResult
            // 
            lblResult.Location = new Point(30, 210);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(398, 193);
            lblResult.TabIndex = 5;
            // 
            // labelTieba1
            // 
            labelTieba1.AutoSize = true;
            labelTieba1.Location = new Point(30, 30);
            labelTieba1.Name = "labelTieba1";
            labelTieba1.Size = new Size(93, 24);
            labelTieba1.TabIndex = 0;
            labelTieba1.Text = "贴吧1名称";
            // 
            // labelTieba2
            // 
            labelTieba2.AutoSize = true;
            labelTieba2.Location = new Point(30, 80);
            labelTieba2.Name = "labelTieba2";
            labelTieba2.Size = new Size(93, 24);
            labelTieba2.TabIndex = 2;
            labelTieba2.Text = "贴吧2名称";
            // 
            // pictureBoxThumb
            // 
            pictureBoxThumb.Location = new Point(350, 180);
            pictureBoxThumb.Name = "pictureBoxThumb";
            pictureBoxThumb.Size = new Size(64, 64);
            pictureBoxThumb.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxThumb.TabIndex = 6;
            pictureBoxThumb.TabStop = false;
            pictureBoxThumb.Visible = false;
            // 
            // txtHotWord
            // 
            txtHotWord.Location = new Point(130, 177);
            txtHotWord.Name = "txtHotWord";
            txtHotWord.Size = new Size(80, 30);
            txtHotWord.TabIndex = 8;
            txtHotWord.Text = "水";
            // 
            // labelHotWord
            // 
            labelHotWord.AutoSize = true;
            labelHotWord.Location = new Point(30, 180);
            labelHotWord.Name = "labelHotWord";
            labelHotWord.Size = new Size(93, 24);
            labelHotWord.TabIndex = 9;
            labelHotWord.Text = "热词";
            // 
            // numPages
            // 
            numPages.Location = new Point(218, 130);
            numPages.Name = "numPages";
            numPages.Size = new Size(112, 30);
            numPages.TabIndex = 7;
            numPages.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numPages.ValueChanged += numPages_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 163);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 9;
            label1.Text = "爬取页数";
        
            // 
            // frmCompare
            // 
            ClientSize = new Size(504, 412);
            Controls.Add(label1);
            Controls.Add(numPages);
            Controls.Add(labelTieba1);
            Controls.Add(txtTieba1);
            Controls.Add(labelTieba2);
            Controls.Add(txtTieba2);
            Controls.Add(btnStartCompare);
            Controls.Add(lblResult);
            Controls.Add(pictureBoxThumb);
            Controls.Add(labelHotWord);
            Controls.Add(txtHotWord);
            Name = "frmCompare";
            Text = "贴吧成分对比";
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumb).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private NumericUpDown numPages;
        private Label label1;
    }
}