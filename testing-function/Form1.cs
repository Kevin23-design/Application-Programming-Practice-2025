namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string s = string.Empty;
            lblinfo.Text = "Hello World! ";
            int currentHour = DateTime.Now.Hour;
            if (currentHour < 12)
            {
                lblinfo.Text += " Good Morning!";
            }
            else if (currentHour < 18)
            {
                lblinfo.Text += " Good Afternoon!";
            }
            else
            {
                lblinfo.Text += " Good Evening!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            ShowCenteredPopup("作者: Kevin\n版本: 1.0.0\n日期: " + DateTime.Now.ToString("yyyy-MM-dd"), "关于");
        }

        private double FindMax(double a, double b, double c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private double FindMin(double a, double b, double c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取三个文本框中的值并转换为double类型
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double num3 = double.Parse(textBox3.Text);

                // 判断两个checkbox的状态
                if (cbxmin.Checked && cbxmax.Checked)
                {
                    double min = FindMin(num1, num2, num3);
                    double max = FindMax(num1, num2, num3);
                    ShowCenteredPopup($"最大值是: {max}\n最小值是: {min}", "结果");
                }
                else if (cbxmin.Checked)
                {
                    double min = FindMin(num1, num2, num3);
                    ShowCenteredPopup("最小值是: " + min.ToString(), "结果");
                }
                else if (cbxmax.Checked)
                {
                    double max = FindMax(num1, num2, num3);
                    ShowCenteredPopup("最大值是: " + max.ToString(), "结果");
                }
            }
            catch (FormatException)
            {
                ShowCenteredPopup("请输入有效的数字。", "错误");
            }
        }

        private void ShowCenteredPopup(string message, string title)
        {
            Form popup = new Form
            {
                Text = title,
                Size = new Size(300, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblMessage = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnClose = new Button
            {
                Text = "关闭",
                Dock = DockStyle.Bottom,
                DialogResult = DialogResult.OK
            };

            popup.Controls.Add(lblMessage);
            popup.Controls.Add(btnClose);

            popup.ShowDialog(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ShowCenteredPopup("选择正确！", "判断结果");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ShowCenteredPopup("选择错误！", "判断结果");
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                ShowCenteredPopup("选择错误！", "判断结果");
            }
        }
    }
}
