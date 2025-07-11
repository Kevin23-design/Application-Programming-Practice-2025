namespace myproject
{
    partial class ResetPwd
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
            txbnNewPwd = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(154, 24);
            label1.TabIndex = 0;
            label1.Text = "请输入您的新密码";
            label1.Click += label1_Click;
            // 
            // txbnNewPwd
            // 
            txbnNewPwd.Location = new Point(12, 81);
            txbnNewPwd.Name = "txbnNewPwd";
            txbnNewPwd.Size = new Size(150, 30);
            txbnNewPwd.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(25, 117);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "修改密码";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ResetPwd
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(txbnNewPwd);
            Controls.Add(label1);
            Name = "ResetPwd";
            Text = "ResetPwd";
            Load += ResetPwd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbnNewPwd;
        private Button btnUpdate;
    }
}