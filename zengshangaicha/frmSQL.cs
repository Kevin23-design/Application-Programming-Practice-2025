using Microsoft.VisualBasic;
using SQL;
using System.Data;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace myproject
{
    public partial class frmSQL : Form
    {
        string msg = string.Empty;
        SQLHelper sh;
        string base_sql = @"
SELECT 
    id AS 序号,
    studentNo AS 学号,
    studentName AS 学生姓名,
    Gender AS 性别,
    Birthday AS 出生日期,
    Major AS 专业,
    QQ,
    Email,
    Phone AS 电话,
    Intro AS 简介,
    Province AS 省份,
    LoginTimes AS 登录次数,
    pwd AS 密码,
    face AS 头像,
    status AS 状态
FROM tblTopStudents WHERE 1=1";

        public frmSQL()
        {
            InitializeComponent();
            sh = new SQLHelper(); //数据库链接对象初始化
        }

        private void btnLink_Click(object sender, EventArgs e)
        {

            string sql = "select count(*) from tblstudents"; //该SQL意思是，获取tblstudents的行数
            try
            {
                string? num = sh.RunSelectSQLToScalar(sql);  //一般运行查询语句
                msg = string.Format("我们班共有{0}个同学!", num);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                sh.Close();
            }
            MessageBox.Show(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentNo = textBox1.Text.Trim();
            string studentName = textBox2.Text.Trim();
            string gender = textBox3.Text.Trim() == "女" ? "1" : "0"; // 数据库存储为1女0男
            string birthday = textBox4.Text.Trim();
            string major = textBox5.Text.Trim();
            string qq = textBox6.Text.Trim();
            string email = textBox7.Text.Trim();
            string phone = textBox8.Text.Trim();
            string province = textBox9.Text.Trim();
            string pwd = textBox10.Text.Trim();

            // 构造SQL语句，注意单引号转义
            string sql = string.Format(
                "UPDATE tblTopStudents SET " +
                "studentName = '{0}', Gender = '{1}', Birthday = '{2}', Major = '{3}', QQ = '{4}', Email = '{5}', Phone = '{6}', Province = '{7}', pwd = '{8}' " +
                "WHERE studentNo = '{9}'",
                studentName.Replace("'", "''"),
                gender,
                birthday.Replace("'", "''"),
                major.Replace("'", "''"),
                qq.Replace("'", "''"),
                email.Replace("'", "''"),
                phone.Replace("'", "''"),
                province.Replace("'", "''"),
                pwd.Replace("'", "''"),
                studentNo.Replace("'", "''")
            );

            try
            {
                int ret = sh.RunSQL(sql);
                if (ret > 0)
                {
                    MessageBox.Show("更新成功！");
                    bindData(base_sql); // 刷新数据
                }
                else
                {
                    MessageBox.Show("未找到对应学号，未更新任何数据。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string studentNo = textBox1.Text;
            string studentName = textBox2.Text;
            string gender = textBox3.Text == "女" ? "1" : "0"; // 数据库存储为1女0男
            string birthday = textBox4.Text;
            string major = textBox5.Text;
            string qq = textBox6.Text;
            string email = textBox7.Text;
            string phone = textBox8.Text;
            string province = textBox9.Text;
            string pwd = textBox10.Text;

            string sql = string.Format("update tblTopStudents set studentName = '{0}' where studentNo = '{1}'", studentName, studentNo);
            try
            {
                int ret = sh.RunSQL(sql); // 执行更新
                if (ret > 0)
                {
                    MessageBox.Show("更新成功！");
                    // 更新后刷新显示
                    bindData(base_sql);
                }
                else
                {
                    MessageBox.Show("未找到对应学号，未更新任何数据。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        /// <summary>
        /// 在初始化之后，内存中加载窗体的时候触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSQL_Load(object sender, EventArgs e)
        {
            bindData(base_sql);
            initCombox();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.DataError += (s, e) => { };

            // 初始化 comboBox1 字段选项
            comboBox1.Items.Clear();
            comboBox1.Items.Add("学号");
            comboBox1.Items.Add("学生姓名");
            comboBox1.Items.Add("性别");
            comboBox1.Items.Add("专业");
            comboBox1.Items.Add("电话");
            comboBox1.Items.Add("邮箱");
            comboBox1.Items.Add("省份");
            comboBox1.Items.Add("状态");
            comboBox1.SelectedIndex = 0;
        }

        // 事件处理方法
        // private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        // {
        //     if (e.RowIndex < 0) return;
        //
        //     if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "学生姓名")
        //     {
        //         DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        //
        //         // 只清除panelDetail中除picFace外的控件
        //         for (int i = panelDetail.Controls.Count - 1; i >= 0; i--)
        //         {
        //             if (panelDetail.Controls[i] != picFace)
        //                 panelDetail.Controls.RemoveAt(i);
        //         }
        //
        //         int y = picFace.Bottom + 15; // 信息从头像下方开始
        //         string facePath = "";
        //
        //         for (int i = 0; i < row.Cells.Count; i++)
        //         {
        //             string header = dataGridView1.Columns[i].HeaderText;
        //             string value = row.Cells[i].Value?.ToString() ?? "";
        //
        //             if (header == "头像")
        //             {
        //                 facePath = value;
        //                 continue;
        //             }
        //
        //             Label lbl = new Label();
        //             lbl.Text = $"{header}: {value}";
        //             lbl.AutoSize = true;
        //             lbl.Location = new Point(10, y);
        //             panelDetail.Controls.Add(lbl);
        //             y += 25;
        //         }
        //
        //         // 显示头像
        //         if (!string.IsNullOrEmpty(facePath))
        //         {
        //             try
        //             {
        //                 picFace.Image = Image.FromFile(facePath);
        //             }
        //             catch
        //             {
        //                 picFace.Image = null;
        //             }
        //         }
        //         else
        //         {
        //             picFace.Image = null;
        //         }
        //     }
        // }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = base_sql;
            string field = comboBox1.Text;
            string keyword = txtStuName.Text.Trim().Replace("'", "''");

            if (!string.IsNullOrEmpty(keyword))
            {
                // 字段名与数据库字段的映射
                string dbField = field switch
                {
                    "学号" => "studentNo",
                    "学生姓名" => "studentName",
                    "性别" => "Gender",
                    "专业" => "Major",
                    "电话" => "Phone",
                    "邮箱" => "Email",
                    "省份" => "Province",
                    "状态" => "status",
                    _ => "studentName"
                };

                sql += $" AND {dbField} LIKE '%{keyword}%'";
            }

            bindData(sql);
        }
        /// <summary>
        /// 给我传递一个SQL命令，我来绑定数据到datagridview
        /// </summary>
        /// <param name="sql">传递过来的SQL命令</param>
        private void bindData(string sql)
        {
            //数据集 mini的database
            DataSet ds = new DataSet();

            try
            {
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];

                // 性别列转换：1为女，0为男
                foreach (DataRow row in dt.Rows)
                {
                    if (dt.Columns.Contains("性别"))
                    {
                        var val = row["性别"]?.ToString();
                        if (val == "1")
                            row["性别"] = "女";
                        else if (val == "0")
                            row["性别"] = "男";
                    }
                }

                dataGridView1.DataSource = dt;
                lblCount.Text = string.Format("共有{0}个同学", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }

        }
        /// <summary>
        /// 用tbltopstudents里面的major来初始化这个combox
        /// </summary>
        private void initCombox()
        {
            string sql = "SELECT DISTINCT major FROM tblTopStudents";
            DataSet ds = new DataSet();

            try
            {
                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                dt.Rows.Add("全部显示");
                // 绑定DataTable到ComboBox
                cboMajor.DataSource = dt;
                cboMajor.DisplayMember = "major";
                // 如果你想将某个列作为值成员，可以这样设置：
                cboMajor.ValueMember = "major";
                cboMajor.Text = "全部显示";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

            bindData(base_sql);  //把数据绑定到datagridview

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
                btnAlert.Text = "停止报警";
            else
                btnAlert.Text = "开始报警";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SearchStu();
        }
        private void SearchStu()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            string sql = "SELECT studentno,STUDENTNAME,gender FROM tblTopStudents\r\nWHERE studentNo NOT IN\r\n(\r\nselect STUDENTNUMBER from tblStudentAbsent where DATEDIFF(DAY,dtedate,GETDATE())=0\r\n)\r\n";
            DataSet ds = new DataSet();
            try
            {

                sh.RunSQL(sql, ref ds);
                DataTable dt = ds.Tables[0];
                bindImgTolist(dt);
                StringBuilder tmp = new StringBuilder();
                foreach (DataRow stu in dt.Rows)
                {
                    tmp.Append(string.Format("学号:{0},姓名:{1}", stu[0], stu[1]));
                    listView1.Items.Add(tmp.ToString());
                }
                //MessageBox.Show(tmp.ToString());
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                sh.Close();
            }
        }
        private void bindImgTolist(DataTable dt)
        {

            foreach (DataRow stu in dt.Rows)
            {
                ListViewItem item1 = new ListViewItem(stu[1].ToString());
                if (stu[2].ToString() == "True")
                    item1.ImageIndex = 0; // 设置为 ImageList 中第一张图片
                else
                    item1.ImageIndex = 1; // 设置为 ImageList 中第一张图片
                listView2.Items.Add(item1);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells["学号"].Value?.ToString() ?? "";
            textBox2.Text = row.Cells["学生姓名"].Value?.ToString() ?? "";
            textBox3.Text = row.Cells["性别"].Value?.ToString() ?? "";
            textBox4.Text = row.Cells["出生日期"].Value?.ToString() ?? "";
            textBox5.Text = row.Cells["专业"].Value?.ToString() ?? "";
            textBox6.Text = row.Cells["QQ"].Value?.ToString() ?? "";
            textBox7.Text = row.Cells["Email"].Value?.ToString() ?? "";
            textBox8.Text = row.Cells["电话"].Value?.ToString() ?? "";
            textBox9.Text = row.Cells["省份"].Value?.ToString() ?? "";
            textBox10.Text = row.Cells["密码"].Value?.ToString() ?? "";

            // 显示头像到 pictureBox1
            string facePath = row.Cells["头像"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(facePath) && System.IO.File.Exists(facePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(facePath);
                }
                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("图片加载失败: " + ex.Message);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentNo = textBox1.Text.Trim();
            string studentName = textBox2.Text.Trim();
            string gender = textBox3.Text.Trim() == "女" ? "1" : "0";
            string birthday = textBox4.Text.Trim();
            string major = textBox5.Text.Trim();
            string qq = textBox6.Text.Trim();
            string email = textBox7.Text.Trim();
            string phone = textBox8.Text.Trim();
            string province = textBox9.Text.Trim();
            string pwd = textBox10.Text.Trim();

            // 先检查学号是否已存在
            string checkSql = $"SELECT COUNT(*) FROM tblTopStudents WHERE studentNo = '{studentNo.Replace("'", "''")}'";
            try
            {
                string? exists = sh.RunSelectSQLToScalar(checkSql);
                if (exists != null && int.TryParse(exists, out int count) && count > 0)
                {
                    MessageBox.Show("该学号已存在，不能重复添加！");
                    return;
                }

                // 插入新学生
                string insertSql = string.Format(
                    "INSERT INTO tblTopStudents " +
                    "(studentNo, studentName, Gender, Birthday, Major, QQ, Email, Phone, Province, pwd) VALUES " +
                    "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    studentNo.Replace("'", "''"),
                    studentName.Replace("'", "''"),
                    gender,
                    birthday.Replace("'", "''"),
                    major.Replace("'", "''"),
                    qq.Replace("'", "''"),
                    email.Replace("'", "''"),
                    phone.Replace("'", "''"),
                    province.Replace("'", "''"),
                    pwd.Replace("'", "''")
                );

                int ret = sh.RunSQL(insertSql);
                if (ret > 0)
                {
                    MessageBox.Show("新建并上传成功！");
                    bindData(base_sql); // 刷新数据
                }
                else
                {
                    MessageBox.Show("插入失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string studentNo = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(studentNo))
            {
                MessageBox.Show("请输入要删除的学号！");
                return;
            }

            // 检查学号是否存在
            string checkSql = $"SELECT COUNT(*) FROM tblTopStudents WHERE studentNo = '{studentNo.Replace("'", "''")}'";
            try
            {
                string? exists = sh.RunSelectSQLToScalar(checkSql);
                if (exists == null || !int.TryParse(exists, out int count) || count == 0)
                {
                    MessageBox.Show("该学号不存在，无法删除！");
                    return;
                }

                // 删除操作
                string delSql = $"DELETE FROM tblTopStudents WHERE studentNo = '{studentNo.Replace("'", "''")}'";
                int ret = sh.RunSQL(delSql);
                if (ret > 0)
                {
                    MessageBox.Show("删除成功！");
                    bindData(base_sql); // 刷新数据
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message);
            }
            finally
            {
                sh.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
