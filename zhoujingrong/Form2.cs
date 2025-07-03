using System;
using System.Windows.Forms;

namespace choices
{
    public partial class Form2 : Form
    {
        private int seconds = 0;
        private bool IsRunning = false;


        public Form2()
        {
            InitializeComponent();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTime.Text = "计时：0 秒";
            timer.Interval = 10; // 每 10 毫秒
            timer.Tick += timer_Tick;

            // 初始化省份
            cboProvince.Items.Clear();
            foreach (var province in addressData.Keys)
            {
                cboProvince.Items.Add(province);
            }
            cboProvince.SelectedIndexChanged += cboProvince_SelectedIndexChanged;
            cboCity.SelectedIndexChanged += cboCity_SelectedIndexChanged;
            cboDistrict.SelectedIndexChanged += cboDistrict_SelectedIndexChanged;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            lblTime.Text = $"计时：{(seconds * 0.01):F2} 秒";
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                IsRunning = false;
                timer.Stop();
                btnTimer.Text = "start";
            }
            else
            {
                seconds = 0;
                lblTime.Text = "计时：0 秒";
                IsRunning = true;
                timer.Start();
                btnTimer.Text = "end";
            }
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = cboProvince.SelectedItem?.ToString();
            cboCity.Items.Clear();
            cboDistrict.Items.Clear();

            if (!string.IsNullOrEmpty(selectedProvince) && addressData.ContainsKey(selectedProvince))
            {
                var cities = addressData[selectedProvince];
                foreach (var city in cities.Keys)
                {
                    cboCity.Items.Add(city);
                }
            }
        }

        private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = cboProvince.SelectedItem?.ToString();
            cboCity.Items.Clear();
            cboDistrict.Items.Clear();

            if (!string.IsNullOrEmpty(selectedProvince) && addressData.ContainsKey(selectedProvince))
            {
                var cities = addressData[selectedProvince];
                foreach (var city in cities.Keys)
                {
                    cboCity.Items.Add(city);
                }
            }
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = cboProvince.SelectedItem?.ToString();
            string selectedCity = cboCity.SelectedItem?.ToString();
            cboDistrict.Items.Clear();

            if (!string.IsNullOrEmpty(selectedProvince) &&
                addressData.ContainsKey(selectedProvince) &&
                addressData[selectedProvince].ContainsKey(selectedCity))
            {
                var districts = addressData[selectedProvince][selectedCity];
                foreach (var district in districts)
                {
                    cboDistrict.Items.Add(district);
                }
            }
        }

        // 模拟省市区数据
        private Dictionary<string, Dictionary<string, List<string>>> addressData = new Dictionary<string, Dictionary<string, List<string>>>
        {
            {
                "广东省", new Dictionary<string, List<string>>
                {
                    { "广州市", new List<string> { "天河区", "越秀区", "白云区" } },
                    { "深圳市", new List<string> { "南山区", "福田区", "罗湖区" } }
                }
            },
            {
                "浙江省", new Dictionary<string, List<string>>
                {
                    { "杭州市", new List<string> { "西湖区", "上城区" } },
                    { "宁波市", new List<string> { "海曙区", "江北区" } }
                }
            }
        };

    }


}
