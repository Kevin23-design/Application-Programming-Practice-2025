namespace myproject
{
    partial class InfromationCheck
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
            label1 = new Label();
            label2 = new Label();
            txbBirthday = new TextBox();
            button1 = new Button();
            txbProvince = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 92);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 1;
            label1.Text = "专业";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 170);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 1;
            label2.Text = "省份";
            label2.Click += label1_Click;
            // 
            // txbBirthday
            // 
            txbBirthday.Location = new Point(127, 92);
            txbBirthday.Name = "txbBirthday";
            txbBirthday.Size = new Size(150, 30);
            txbBirthday.TabIndex = 2;
            txbBirthday.TextChanged += txbBirthday_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(447, 113);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "提交";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txbProvince
            // 
            txbProvince.Location = new Point(127, 167);
            txbProvince.Name = "txbProvince";
            txbProvince.Size = new Size(150, 30);
            txbProvince.TabIndex = 4;
            txbProvince.TextChanged += txbProvince_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 249);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 252);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 5;
            label3.Text = "生日";
            // 
            // InfromationCheck
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(txbProvince);
            Controls.Add(button1);
            Controls.Add(txbBirthday);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InfromationCheck";
            Text = "InfromationCheck";
            Load += InfromationCheck_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox txbBirthday;
        private Button button1;
        private TextBox txbProvince;
        private TextBox textBox1;
        private Label label3;
    }
}