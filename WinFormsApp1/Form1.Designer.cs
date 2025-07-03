namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            lblinfo = new Label();
            btnInfo = new Button();
            求最值 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            cbxmax = new CheckBox();
            cbxmin = new CheckBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblinfo
            // 
            lblinfo.AutoSize = true;
            lblinfo.Font = new Font("Comic Sans MS", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblinfo.Location = new Point(12, 21);
            lblinfo.Name = "lblinfo";
            lblinfo.Size = new Size(176, 39);
            lblinfo.TabIndex = 0;
            lblinfo.Text = "Hello World";
            lblinfo.Click += label1_Click;
            // 
            // btnInfo
            // 
            btnInfo.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnInfo.Location = new Point(723, 12);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(110, 48);
            btnInfo.TabIndex = 1;
            btnInfo.Text = "关于";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // 求最值
            // 
            求最值.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            求最值.Location = new Point(723, 82);
            求最值.Name = "求最值";
            求最值.Size = new Size(110, 48);
            求最值.TabIndex = 2;
            求最值.Text = "最值";
            求最值.UseVisualStyleBackColor = true;
            求最值.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(228, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(426, 93);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 30);
            textBox3.TabIndex = 5;
            // 
            // cbxmax
            // 
            cbxmax.AutoSize = true;
            cbxmax.Location = new Point(630, 73);
            cbxmax.Name = "cbxmax";
            cbxmax.Size = new Size(72, 28);
            cbxmax.TabIndex = 6;
            cbxmax.Text = "最大";
            cbxmax.UseVisualStyleBackColor = true;
            // 
            // cbxmin
            // 
            cbxmin.AutoSize = true;
            cbxmin.Location = new Point(630, 129);
            cbxmin.Name = "cbxmin";
            cbxmin.Size = new Size(72, 28);
            cbxmin.TabIndex = 7;
            cbxmin.Text = "最小";
            cbxmin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(20, 218);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 237);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "做题区";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(6, 40);
            label1.Name = "label1";
            label1.Size = new Size(182, 31);
            label1.TabIndex = 9;
            label1.Text = "中国的首都是：";
            label1.Click += label1_Click_1;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 161);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(71, 28);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "杭州";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += RadioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 127);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(71, 28);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "上海";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 93);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(71, 28);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "北京";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 811);
            Controls.Add(groupBox1);
            Controls.Add(cbxmin);
            Controls.Add(cbxmax);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(求最值);
            Controls.Add(btnInfo);
            Controls.Add(lblinfo);
            Name = "Form1";
            Text = "我的窗口";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblinfo;
        private Button btnInfo;
        private Button 求最值;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private CheckBox cbxmax;
        private CheckBox cbxmin;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label1;
    }
}
