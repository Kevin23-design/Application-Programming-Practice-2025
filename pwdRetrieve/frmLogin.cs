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
using SecurityUtils;
namespace myproject
{
    public partial class frmLogin : Form
    {
        string stuNo, stuPwd;
        SQLHelper sh;
        public frmLogin()
        {
            InitializeComponent();
            sh = new SQLHelper(); //数据库链接对象初始化
            this.StartPosition = FormStartPosition.CenterScreen;

            // 读取设置
            txtUserNo.Text = Properties.Settings.Default.UserNo;
            if (Properties.Settings.Default.RememberMe == "true")
            {
                txtPwd.Text = Properties.Settings.Default.UserPwd;
                checkBox1.Checked = true;
            }
            else
            {
                txtPwd.Text = "";
                checkBox1.Checked = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            stuNo = txtUserNo.Text;
            stuPwd = txtPwd.Text;

            // 保存设置
            Properties.Settings.Default.UserNo = stuNo;
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.UserPwd = stuPwd;
                Properties.Settings.Default.RememberMe = "true";
            }
            else
            {
                Properties.Settings.Default.UserPwd = "";
                Properties.Settings.Default.RememberMe = "false";
            }
            Properties.Settings.Default.AutoLogin = "true";
            Properties.Settings.Default.Save();

            string sql = string.Format("select pwd,salt from tblTopstudents where studentNo='{0}'", stuNo);

            try
            {
                // 函数名一样，参数不一样，这在OO里面叫重载 overload
                DataSet ds = new DataSet();
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                //1个dataset包含落干个datatable
                if (dt.Rows.Count > 0)
                {
                    string pwd = dt.Rows[0]["pwd"].ToString();
                    string salt = dt.Rows[0]["salt"].ToString();
                    if (PasswordHelper.VerifyHash(stuPwd, salt, pwd))
                    {
                        frmMain fm = new frmMain();
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        var result = MessageBox.Show(
                            "密码不匹配！\n是否进行信息核验？选择“否”则进入找回密码。",
                            "提示",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            InfromationCheck infoCheckForm = new InfromationCheck();
                            infoCheckForm.ShowDialog();
                        }
                        else if (result == DialogResult.No)
                        {
                            GetPwdBack getPwdBackForm = new GetPwdBack();
                            getPwdBackForm.ShowDialog();
                        }
                        // Cancel 不做处理
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在！");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sh.Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
