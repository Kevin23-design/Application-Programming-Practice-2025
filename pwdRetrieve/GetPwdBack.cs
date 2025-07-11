using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQL;

namespace myproject
{
    public partial class GetPwdBack : Form
    {
        private string sentCode = ""; // 保存验证码

        public GetPwdBack()
        {
            InitializeComponent();
        }

        private void GetPwdBack_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string stuNo = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(stuNo))
            {
                MessageBox.Show("请输入学号！");
                return;
            }

            SQLHelper sh = new SQLHelper();
            string sql = $"SELECT email FROM tblTopstudents WHERE studentNo='{stuNo}'";
            try
            {
                DataSet ds = new DataSet();
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string email = dt.Rows[0]["email"].ToString();
                    // 生成4位随机验证码
                    Random rnd = new Random();
                    sentCode = rnd.Next(1000, 10000).ToString();

                    // 发送邮件
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("3534704571@qq.com"); // 替换为你的邮箱
                    mail.To.Add(email);
                    mail.Subject = "验证码";
                    mail.Body = $"您的验证码为：{sentCode}";

                    SmtpClient smtp = new SmtpClient("smtp.qq.com"); // 替换为你的SMTP服务器
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("3534704571@qq.com", "fszudlqxbqmedbdd"); // 替换为你的邮箱和密码
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show($"验证码已发送到邮箱：{email}");
                }
                else
                {
                    MessageBox.Show("未找到该学号对应的邮箱！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询或发送邮件出错：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void txbVerification_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVerification_Click(object sender, EventArgs e)
        {
            if (txbVerification.Text.Trim() == sentCode && !string.IsNullOrEmpty(sentCode))
            {
                MessageBox.Show("验证成功！");
                ResetPwd resetPwdForm = new ResetPwd();
                resetPwdForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("验证码错误！");
            }
        }
    }
}
