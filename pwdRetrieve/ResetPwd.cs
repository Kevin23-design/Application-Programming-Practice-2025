using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecurityUtils;
using SQL;

namespace myproject
{
    public partial class ResetPwd : Form
    {
        public ResetPwd()
        {
            InitializeComponent();
        }

        private void ResetPwd_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newPwd = txbnNewPwd.Text.Trim();
            string stuNo = Properties.Settings.Default.UserNo; // 使用UserNo

            if (string.IsNullOrEmpty(stuNo))
            {
                MessageBox.Show("学号不能为空！");
                return;
            }
            if (newPwd.Length < 6)
            {
                MessageBox.Show("密码长度不能小于6位！");
                return;
            }

            string salt;
            string hash = PasswordHelper.CreateHash(newPwd, out salt);

            SQLHelper sh = new SQLHelper();
            try
            {
                string sql = string.Format(@"update tblTopStudents set pwd='{0}', salt='{1}' where studentNo='{2}'", hash, salt, stuNo);
                int ret = sh.RunSQL(sql);
                MessageBox.Show("密码重置成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
