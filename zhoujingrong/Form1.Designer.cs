namespace choices
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
            lblQuestion = new Label();
            radA = new RadioButton();
            radB = new RadioButton();
            radC = new RadioButton();
            btnSubmit = new Button();
            groupBox1 = new GroupBox();
            btnNext = new Button();
            btnLast = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(50, 37);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(63, 24);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "label1";
            // 
            // radA
            // 
            radA.AutoSize = true;
            radA.Location = new Point(50, 103);
            radA.Name = "radA";
            radA.Size = new Size(149, 28);
            radA.TabIndex = 1;
            radA.TabStop = true;
            radA.Text = "radioButton1";
            radA.UseVisualStyleBackColor = true;
            radA.Click += RadioButton_CheckedChanged;
            // 
            // radB
            // 
            radB.AutoSize = true;
            radB.Location = new Point(50, 163);
            radB.Name = "radB";
            radB.Size = new Size(149, 28);
            radB.TabIndex = 2;
            radB.TabStop = true;
            radB.Text = "radioButton2";
            radB.UseVisualStyleBackColor = true;
            radB.Click += RadioButton_CheckedChanged;
            // 
            // radC
            // 
            radC.AutoSize = true;
            radC.Location = new Point(50, 221);
            radC.Name = "radC";
            radC.Size = new Size(149, 28);
            radC.TabIndex = 3;
            radC.TabStop = true;
            radC.Text = "radioButton3";
            radC.UseVisualStyleBackColor = true;
            radC.Click += RadioButton_CheckedChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(485, 39);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radC);
            groupBox1.Controls.Add(radB);
            groupBox1.Controls.Add(radA);
            groupBox1.Controls.Add(lblQuestion);
            groupBox1.Location = new Point(52, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 337);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "做题区";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(603, 105);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 8;
            btnNext.Text = "下一题";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(485, 105);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(112, 34);
            btnLast.TabIndex = 9;
            btnLast.Text = "上一题";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(groupBox1);
            Controls.Add(btnSubmit);
            Name = "Form1";
            Text = "2025.7.1 选择题模拟器";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblQuestion;
        private RadioButton radA;
        private RadioButton radB;
        private RadioButton radC;
        private Button btnSubmit;
        private GroupBox groupBox1;
        private Button btnNext;
        private Button btnLast;
    }
}
