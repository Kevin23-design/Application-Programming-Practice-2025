namespace myproject
{
    partial class frmSQL
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
            btnLink = new Button();
            btnInsert = new Button();
            dataGridView1 = new DataGridView();
            cboMajor = new ComboBox();
            txtStuName = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            label2 = new Label();
            chkAll = new CheckBox();
            lblCount = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            listView2 = new ListView();
            listView1 = new ListView();
            btnAlert = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            label11 = new Label();
            label12 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            textBox11 = new TextBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLink
            // 
            btnLink.Location = new Point(61, 58);
            btnLink.Margin = new Padding(5, 4, 5, 4);
            btnLink.Name = "btnLink";
            btnLink.Size = new Size(192, 32);
            btnLink.TabIndex = 0;
            btnLink.Text = "测试数据库链接";
            btnLink.UseVisualStyleBackColor = true;
            btnLink.Click += btnLink_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(317, 58);
            btnInsert.Margin = new Padding(5, 4, 5, 4);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(192, 32);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "一键打卡";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(61, 250);
            dataGridView1.Margin = new Padding(5, 4, 5, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(894, 617);
            dataGridView1.TabIndex = 2;
            // 
            // cboMajor
            // 
            cboMajor.FormattingEnabled = true;
            cboMajor.Location = new Point(121, 119);
            cboMajor.Margin = new Padding(5, 4, 5, 4);
            cboMajor.Name = "cboMajor";
            cboMajor.Size = new Size(248, 32);
            cboMajor.TabIndex = 3;
            // 
            // txtStuName
            // 
            txtStuName.Location = new Point(121, 162);
            txtStuName.Margin = new Padding(5, 4, 5, 4);
            txtStuName.Name = "txtStuName";
            txtStuName.Size = new Size(248, 30);
            txtStuName.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(380, 162);
            btnSearch.Margin = new Padding(5, 4, 5, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(129, 32);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "查找";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 165);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 6;
            label1.Text = "请输入信息";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 119);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 7;
            label2.Text = "专业";
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Location = new Point(429, 121);
            chkAll.Margin = new Padding(5, 4, 5, 4);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(72, 28);
            chkAll.TabIndex = 8;
            chkAll.Text = "全部";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(61, 222);
            lblCount.Margin = new Padding(5, 0, 5, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(63, 24);
            lblCount.TabIndex = 9;
            lblCount.Text = "label3";
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // listView2
            // 
            listView2.Location = new Point(1916, 861);
            listView2.Margin = new Padding(5, 4, 5, 4);
            listView2.Name = "listView2";
            listView2.Size = new Size(10, 10);
            listView2.TabIndex = 12;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            // 
            // listView1
            // 
            listView1.Location = new Point(1896, 861);
            listView1.Margin = new Padding(5, 4, 5, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(10, 10);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // btnAlert
            // 
            btnAlert.Location = new Point(1896, 843);
            btnAlert.Margin = new Padding(5, 4, 5, 4);
            btnAlert.Name = "btnAlert";
            btnAlert.Size = new Size(10, 10);
            btnAlert.TabIndex = 10;
            btnAlert.Text = "开始报警";
            btnAlert.UseVisualStyleBackColor = true;
            btnAlert.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1095, 250);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1095, 303);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1095, 374);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 30);
            textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1095, 429);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 30);
            textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1095, 493);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 30);
            textBox5.TabIndex = 17;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(1095, 555);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(150, 30);
            textBox6.TabIndex = 18;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(1095, 627);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(150, 30);
            textBox7.TabIndex = 19;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(1095, 690);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(150, 30);
            textBox8.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1009, 256);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 21;
            label3.Text = "学号";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1009, 306);
            label4.Name = "label4";
            label4.Size = new Size(46, 24);
            label4.TabIndex = 22;
            label4.Text = "姓名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1009, 374);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 23;
            label5.Text = "性别";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(991, 435);
            label6.Name = "label6";
            label6.Size = new Size(82, 24);
            label6.TabIndex = 24;
            label6.Text = "出生日期";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1009, 493);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 25;
            label7.Text = "专业";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1015, 555);
            label8.Name = "label8";
            label8.Size = new Size(40, 24);
            label8.TabIndex = 26;
            label8.Text = "QQ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1009, 627);
            label9.Name = "label9";
            label9.Size = new Size(57, 24);
            label9.TabIndex = 27;
            label9.Text = "Email";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1015, 696);
            label10.Name = "label10";
            label10.Size = new Size(46, 24);
            label10.TabIndex = 28;
            label10.Text = "电话";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(1095, 750);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(150, 30);
            textBox9.TabIndex = 29;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(1095, 813);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(150, 30);
            textBox10.TabIndex = 30;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(1015, 756);
            label11.Name = "label11";
            label11.Size = new Size(46, 24);
            label11.TabIndex = 31;
            label11.Text = "省份";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1015, 819);
            label12.Name = "label12";
            label12.Size = new Size(46, 24);
            label12.TabIndex = 32;
            label12.Text = "密码";
            // 
            // button1
            // 
            button1.Location = new Point(1095, 109);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 33;
            button1.Text = "修改";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1095, 149);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 35;
            button2.Text = "新建";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1095, 189);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 37;
            button3.Text = "删除";
            button3.UseVisualStyleBackColor = true;
            button3.UseWaitCursor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1302, 109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 257);
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(559, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 32);
            comboBox1.TabIndex = 100;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(1392, 816);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(150, 30);
            textBox11.TabIndex = 101;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1304, 822);
            label13.Name = "label13";
            label13.Size = new Size(82, 24);
            label13.TabIndex = 102;
            label13.Text = "重复密码";
            // 
            // frmSQL
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(2411, 884);
            Controls.Add(label13);
            Controls.Add(textBox11);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(btnAlert);
            Controls.Add(lblCount);
            Controls.Add(chkAll);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtStuName);
            Controls.Add(cboMajor);
            Controls.Add(dataGridView1);
            Controls.Add(btnInsert);
            Controls.Add(btnLink);
            Margin = new Padding(5, 4, 5, 4);
            Name = "frmSQL";
            Load += frmSQL_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLink;
        private Button btnInsert;
        private DataGridView dataGridView1;
        private ComboBox cboMajor;
        private TextBox txtStuName;
        private Button btnSearch;
        private Label label1;
        private Label label2;
        private CheckBox chkAll;
        private Label lblCount;
        private System.Windows.Forms.Timer timer1;
        private ListView listView2;
        private ListView listView1;
        private Button btnAlert;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label11;
        private Label label12;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private TextBox textBox11;
        private Label label13;
    }
}