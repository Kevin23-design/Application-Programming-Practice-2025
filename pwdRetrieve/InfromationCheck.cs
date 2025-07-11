using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQL;

namespace myproject
{
    public partial class InfromationCheck : Form
    {
        public InfromationCheck()
        {
            InitializeComponent();
        }

        private void InfromationCheck_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbBirthday_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stuNo = Properties.Settings.Default.UserNo; // 当前用户学号
            string birthday = textBox1.Text.Trim(); // 生日输入框
            string province = txbProvince.Text.Trim(); // 省份输入框

            if (string.IsNullOrEmpty(stuNo) || string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(province))
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }

            SQLHelper sh = new SQLHelper();
            string sql = $"SELECT COUNT(*) FROM tblTopStudents WHERE studentNo='{stuNo}' AND birthday='{birthday}' AND province='{province}'";
            try
            {
                string? result = sh.RunSelectSQLToScalar(sql);
                if (result == "1")
                {
                    MessageBox.Show("信息核验成功！");
                    ResetPwd resetPwdForm = new ResetPwd();
                    resetPwdForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("信息核验失败，请检查输入！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("核验出错：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void txbProvince_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
