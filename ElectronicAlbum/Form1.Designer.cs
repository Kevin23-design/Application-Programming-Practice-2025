namespace ElectronicAlbum
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox chkSlideShow;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Timer slideShowTimer;

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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            txtPage = new TextBox();
            btnGo = new Button();
            chkSlideShow = new CheckBox();
            progressBar = new ProgressBar();
            lblDescription = new Label();
            slideShowTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(50, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // txtPage
            // 
            txtPage.Location = new Point(50, 370);
            txtPage.Name = "txtPage";
            txtPage.Size = new Size(100, 30);
            txtPage.TabIndex = 1;
            // 
            // btnGo
            // 
            btnGo.Location = new Point(160, 370);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 30);
            btnGo.TabIndex = 2;
            btnGo.Text = "跳转";
            btnGo.Click += btnGo_Click;
            // 
            // chkSlideShow
            // 
            chkSlideShow.Location = new Point(241, 370);
            chkSlideShow.Name = "chkSlideShow";
            chkSlideShow.Size = new Size(100, 30);
            chkSlideShow.TabIndex = 3;
            chkSlideShow.Text = "幻灯片播放";
            chkSlideShow.CheckedChanged += chkSlideShow_CheckedChanged;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(50, 419);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(700, 23);
            progressBar.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(50, 450);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(700, 23);
            lblDescription.TabIndex = 5;
            // 
            // slideShowTimer
            // 
            slideShowTimer.Interval = 2000;
            slideShowTimer.Tick += slideShowTimer_Tick;
            // 
            // Form1
            // 
            ClientSize = new Size(820, 887);
            Controls.Add(pictureBox1);
            Controls.Add(txtPage);
            Controls.Add(btnGo);
            Controls.Add(chkSlideShow);
            Controls.Add(progressBar);
            Controls.Add(lblDescription);
            Name = "Form1";
            Text = "电子相簿";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
