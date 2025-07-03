namespace choices
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            lblTime = new Label();
            btnTimer = new Button();
            timer = new System.Windows.Forms.Timer(components);
            cboProvince = new ComboBox();
            cboCity = new ComboBox();
            cboDistrict = new ComboBox();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(441, 145);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(63, 24);
            lblTime.TabIndex = 0;
            lblTime.Text = "label1";
            // 
            // btnTimer
            // 
            btnTimer.Location = new Point(559, 146);
            btnTimer.Name = "btnTimer";
            btnTimer.Size = new Size(112, 34);
            btnTimer.TabIndex = 1;
            btnTimer.Text = "start";
            btnTimer.UseVisualStyleBackColor = true;
            btnTimer.Click += btnTimer_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // cboProvince
            // 
            cboProvince.FormattingEnabled = true;
            cboProvince.Items.AddRange(new object[] { "a", "b", "c", "d" });
            cboProvince.Location = new Point(12, 307);
            cboProvince.Name = "cboProvince";
            cboProvince.Size = new Size(182, 32);
            cboProvince.TabIndex = 2;
            cboProvince.SelectedIndexChanged += cboProvince_SelectedIndexChanged;
            // 
            // cboCity
            // 
            cboCity.FormattingEnabled = true;
            cboCity.Location = new Point(249, 308);
            cboCity.Name = "cboCity";
            cboCity.Size = new Size(182, 32);
            cboCity.TabIndex = 3;
            cboCity.SelectedIndexChanged += cboCity_SelectedIndexChanged;
            // 
            // cboDistrict
            // 
            cboDistrict.FormattingEnabled = true;
            cboDistrict.Location = new Point(468, 308);
            cboDistrict.Name = "cboDistrict";
            cboDistrict.Size = new Size(182, 32);
            cboDistrict.TabIndex = 4;
            cboDistrict.SelectedIndexChanged += cboDistrict_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboDistrict);
            Controls.Add(cboCity);
            Controls.Add(cboProvince);
            Controls.Add(btnTimer);
            Controls.Add(lblTime);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTime;
        private Button btnTimer;
        private System.Windows.Forms.Timer timer;
        private ComboBox cboProvince;
        private ComboBox cboCity;
        private ComboBox cboDistrict;
    }
}