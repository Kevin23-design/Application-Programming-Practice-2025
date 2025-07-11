namespace myproject
{
    partial class GetPwdBack
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
            btnSend = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txbVerification = new TextBox();
            btnVerification = new Button();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(43, 114);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 34);
            btnSend.TabIndex = 0;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 51);
            label1.Name = "label1";
            label1.Size = new Size(136, 24);
            label1.TabIndex = 2;
            label1.Text = "请输入您的学号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 51);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 3;
            label2.Text = "验证码";
            // 
            // txbVerification
            // 
            txbVerification.Location = new Point(310, 78);
            txbVerification.Name = "txbVerification";
            txbVerification.Size = new Size(150, 30);
            txbVerification.TabIndex = 4;
            txbVerification.TextChanged += txbVerification_TextChanged;
            // 
            // btnVerification
            // 
            btnVerification.Location = new Point(310, 114);
            btnVerification.Name = "btnVerification";
            btnVerification.Size = new Size(112, 34);
            btnVerification.TabIndex = 5;
            btnVerification.Text = "提交验证";
            btnVerification.UseVisualStyleBackColor = true;
            btnVerification.Click += btnVerification_Click;
            // 
            // GetPwdBack
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerification);
            Controls.Add(txbVerification);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnSend);
            Name = "GetPwdBack";
            Text = "GetPwdBack";
            Load += GetPwdBack_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox txbVerification;
        private Button btnVerification;
    }
}