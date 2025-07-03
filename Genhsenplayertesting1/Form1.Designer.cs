namespace Genhsenplayertesting
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(189, 101);
            label1.Name = "label1";
            label1.Size = new Size(687, 144);
            label1.TabIndex = 0;
            label1.Text = "同学您好，欢迎参加本次原神玩家测试\r\n在此，你将扮演一位天命人，做五道与原神相关的题目\r\n正确率越高，越能证明你是一位资深的原神玩家\r\n请问你准备好了吗？\r\n";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(157, 344);
            button1.Name = "button1";
            button1.Size = new Size(188, 73);
            button1.TabIndex = 1;
            button1.Text = "我准备好了";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(714, 344);
            button2.Name = "button2";
            button2.Size = new Size(188, 73);
            button2.TabIndex = 2;
            button2.Text = "我需要再准备准备";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 580);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "GenshinPlayerTest";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
    }
}
