namespace choices
{
    partial class FormAlbum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            labelDescription = new Label();
            comboBoxAlbum = new ComboBox();
            comboBoxPhoto = new ComboBox();
            buttonPrevious = new Button();
            buttonNext = new Button();
            progressBar1 = new ProgressBar();
            labelIndex = new Label();
            checkBoxSlide = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            label3 = new Label();
            btnFullScreen = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(61, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(599, 566);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 693);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 1;
            label1.Text = "相册";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(466, 693);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 2;
            label2.Text = "照片";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.BorderStyle = BorderStyle.FixedSingle;
            labelDescription.FlatStyle = FlatStyle.Flat;
            labelDescription.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 134);
            labelDescription.Location = new Point(204, 620);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(308, 44);
            labelDescription.TabIndex = 3;
            labelDescription.Text = "你还没有选择相册！";
            labelDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxAlbum
            // 
            comboBoxAlbum.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAlbum.FormattingEnabled = true;
            comboBoxAlbum.Location = new Point(141, 720);
            comboBoxAlbum.Name = "comboBoxAlbum";
            comboBoxAlbum.Size = new Size(182, 32);
            comboBoxAlbum.TabIndex = 4;
            comboBoxAlbum.SelectedIndexChanged += comboBoxAlbum_SelectedIndexChanged;
            // 
            // comboBoxPhoto
            // 
            comboBoxPhoto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPhoto.Enabled = false;
            comboBoxPhoto.FormattingEnabled = true;
            comboBoxPhoto.Location = new Point(402, 720);
            comboBoxPhoto.Name = "comboBoxPhoto";
            comboBoxPhoto.Size = new Size(182, 32);
            comboBoxPhoto.TabIndex = 5;
            comboBoxPhoto.SelectedIndexChanged += comboBoxPhoto_SelectedIndexChanged;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Enabled = false;
            buttonPrevious.Location = new Point(185, 815);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(112, 34);
            buttonPrevious.TabIndex = 6;
            buttonPrevious.Text = "上一张";
            buttonPrevious.UseVisualStyleBackColor = true;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.Enabled = false;
            buttonNext.Location = new Point(425, 814);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(112, 34);
            buttonNext.TabIndex = 7;
            buttonNext.Text = "下一张";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = SystemColors.ControlDark;
            progressBar1.Location = new Point(61, 758);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(599, 34);
            progressBar1.TabIndex = 8;
            // 
            // labelIndex
            // 
            labelIndex.AutoSize = true;
            labelIndex.Location = new Point(342, 819);
            labelIndex.Name = "labelIndex";
            labelIndex.Size = new Size(40, 24);
            labelIndex.TabIndex = 9;
            labelIndex.Text = "0/0";
            labelIndex.Visible = false;
            // 
            // checkBoxSlide
            // 
            checkBoxSlide.AutoSize = true;
            checkBoxSlide.Location = new Point(568, 815);
            checkBoxSlide.Name = "checkBoxSlide";
            checkBoxSlide.Size = new Size(90, 28);
            checkBoxSlide.TabIndex = 10;
            checkBoxSlide.Text = "幻灯片";
            checkBoxSlide.UseVisualStyleBackColor = true;
            checkBoxSlide.CheckedChanged += checkBoxSlide_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(668, 855);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(58, 30);
            textBox1.TabIndex = 11;
            textBox1.Text = "2";
            textBox1.Validating += textBox1_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(556, 858);
            label3.Name = "label3";
            label3.Size = new Size(102, 24);
            label3.TabIndex = 12;
            label3.Text = "切换时间(s)";
            // 
            // btnFullScreen
            // 
            btnFullScreen.Location = new Point(12, 858);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(112, 34);
            btnFullScreen.TabIndex = 13;
            btnFullScreen.Text = "全屏";
            btnFullScreen.UseVisualStyleBackColor = true;
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // FormAlbum
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 898);
            Controls.Add(btnFullScreen);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(checkBoxSlide);
            Controls.Add(labelIndex);
            Controls.Add(progressBar1);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrevious);
            Controls.Add(comboBoxPhoto);
            Controls.Add(comboBoxAlbum);
            Controls.Add(labelDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Margin = new Padding(6);
            Name = "FormAlbum";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "数字相册";
            Load += FormAlbum_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label labelDescription;
        private ComboBox comboBoxAlbum;
        private ComboBox comboBoxPhoto;
        private Button buttonPrevious;
        private Button buttonNext;
        private ProgressBar progressBar1;
        private Label labelIndex;
        private CheckBox checkBoxSlide;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox1;
        private Label label3;
        private Button btnFullScreen;
    }
}