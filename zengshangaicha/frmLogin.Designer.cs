namespace myproject
{
    partial class frmLogin
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
            txtUserNo = new TextBox();
            txtUserName = new TextBox();
            label2 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 88);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 0;
            label1.Text = "学号";
            // 
            // txtUserNo
            // 
            txtUserNo.Location = new Point(194, 82);
            txtUserNo.Name = "txtUserNo";
            txtUserNo.Size = new Size(150, 30);
            txtUserNo.TabIndex = 1;
            txtUserNo.TextChanged += txtUserNo_TextChanged;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(194, 140);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(150, 30);
            txtUserName.TabIndex = 3;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 146);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 2;
            label2.Text = "密码";
            // 
            // button1
            // 
            button1.Location = new Point(194, 245);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(353, 251);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(144, 28);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "下次自动登录";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(txtUserNo);
            Controls.Add(label1);
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUserNo;
        private TextBox txtUserName;
        private Label label2;
        private Button button1;
        private CheckBox checkBox1;
    }
}