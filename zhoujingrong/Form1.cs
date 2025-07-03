namespace choices
{
    public partial class Form1 : Form
    {
        // 类级变量
        string[] questions = {
        "1. 计算机的中央处理器简称是什么？",
        "2. 下列哪项是操作系统？",
        "3. 二进制的基本数位有哪两个？",
        "4. C# 属于哪种类型的编程语言？",
        "5. 下列哪项是数据库管理系统？"
    };

        string[,] options = {
        { "CPU", "GPU", "RAM" },
        { "Windows", "Photoshop", "Word" },
        { "0 和 1", "1 和 2", "A 和 B" },
        { "解释型", "编译型", "脚本型" },
        { "MySQL", "HTML", "Excel" }
    };
        int[] answers = { 0, 0, 0, 1, 0 };  // 正确选项的下标
        int[] selected = { -1, -1, -1, -1, -1 }; // 用于存储用户选择的答案
        int currentQuestionIndex = 0;
        bool isProgrammaticChange = false;

        string ResultText = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowQuestion(int index)
        {
            lblQuestion.Text = questions[index];
            radA.Text = options[index, 0];
            radB.Text = options[index, 1];
            radC.Text = options[index, 2];

            // 取消选中
            isProgrammaticChange = true;
            radA.Checked = selected[index] == 0;
            radB.Checked = selected[index] == 1;
            radC.Checked = selected[index] == 2;
            isProgrammaticChange = false;

            UpdateNavigationButtons(); // ← 新增：更新按钮颜色
        }

        // 新增方法：根据位置更新按钮状态和颜色
        private void UpdateNavigationButtons()
        {
            // 第一题时禁用“上一题”按钮或变色
            if (currentQuestionIndex == 0)
            {
                btnLast.Enabled = false;
                btnLast.BackColor = Color.LightGray;
            }
            else
            {
                btnLast.Enabled = true;
                btnLast.BackColor = SystemColors.Control;
            }

            // 最后一题时禁用“下一题”按钮或变色
            if (currentQuestionIndex == questions.Length - 1)
            {
                btnNext.Enabled = false;
                btnNext.BackColor = Color.LightGray;
            }
            else
            {
                btnNext.Enabled = true;
                btnNext.BackColor = SystemColors.Control;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (selected[i] == -1)
                {
                    MessageBox.Show($"第{i + 1}题还未作答！");
                    ShowQuestion(i); // 显示未作答的题目
                    return;
                }
            }

            int cnt = 0;
            for (int i = 0; i < selected.Length; i++)
            {
                if (selected[i] == answers[i])
                {
                    cnt++;
                }
            }

            if (cnt == questions.Length)
            {
                MessageBox.Show("恭喜你，全部答对了！");
                return;
            }

            //如果没全对
            ResultText = $"你答对了 {cnt} 道题目！\n";
            for (int i = 0; i < answers.Length; i++)
            {
                if (selected[i] != answers[i])
                {
                    ResultText += $"第{i + 1}题回答错误！正确答案是：{options[i, answers[i]]}\n";
                }

            }
            MessageBox.Show(ResultText, "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResultText = ""; // 清空结果文本
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowQuestion(currentQuestionIndex);

            radA.Tag = 0;
            radB.Tag = 1;
            radC.Tag = 2;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex == questions.Length -1) 
            {
                return;
            }
            currentQuestionIndex += 1;
            ShowQuestion(currentQuestionIndex);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex == 0)
            {
                return;
            }
            currentQuestionIndex -= 1;
            ShowQuestion(currentQuestionIndex);
        }


        // 单选按钮选中状态变化事件处理方法
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // 如果是程序设置的选中状态，则不处理
            if (isProgrammaticChange) return;

            // 将 sender 转换为 RadioButton 类型
            var radio = sender as RadioButton;

            // 如果当前单选按钮被选中
            if (radio != null && radio.Checked)
            {
                // 记录当前题目的用户选择
                selected[currentQuestionIndex] = (int)radio.Tag;
            }
        }


    }
}
