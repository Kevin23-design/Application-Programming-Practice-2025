using System;
using System.Linq;
using System.Windows.Forms; // 确保明确使用 System.Windows.Forms.Timer

namespace Genhsenplayertesting
{
    public partial class Form1 : Form
    {
        private class Question
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectIndex { get; set; }
        }

        // 题库
        private readonly Question[] questions = new Question[]
        {
            new Question { Text = "第1题：下列哪位角色不是原神中的角色？", Options = new[] { "琴", "迪卢克", "孙悟空" }, CorrectIndex = 2 },
            new Question { Text = "第2题：下列哪种元素不存在于原神？", Options = new[] { "风", "水", "金" }, CorrectIndex = 2 },
            new Question { Text = "第3题：下列哪位角色是璃月港的七星之一？", Options = new[] { "刻晴", "安柏", "芭芭拉" }, CorrectIndex = 0 },
            new Question { Text = "第4题：下列哪种武器类型不是原神中的？", Options = new[] { "法杖", "弓", "双手剑" }, CorrectIndex = 0 },
            new Question { Text = "第5题：下列哪位角色的元素属性是冰？", Options = new[] { "重云", "香菱", "雷泽" }, CorrectIndex = 0 }
        };

        private int currentQuestion = 0;
        private int[] userAnswers = new int[5];

        private System.Windows.Forms.Timer countdownTimer; // 明确指定 Timer 的命名空间
        private int countdownSeconds = 120; // 2分钟
        private ProgressBar progressBar;
        private Label timeLabel;
        private Panel timerPanel;

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 显示倒计时和进度条
            StartCountdown();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("旅行者，期待您在准备好后，来参加测试！", "提示");
        }

        private void StartCountdown()
        {
            // 初始化答题状态
            currentQuestion = 0;
            userAnswers = Enumerable.Repeat(-1, questions.Length).ToArray();

            // 显示第一题
            ShowQuestion(currentQuestion);

            // 创建右下角定时器面板
            if (timerPanel != null && this.Controls.Contains(timerPanel))
                this.Controls.Remove(timerPanel);

            timerPanel = new Panel();
            timerPanel.Width = 420;
            timerPanel.Height = 70;
            timerPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            timerPanel.BorderStyle = BorderStyle.FixedSingle;

            // 倒计时Label
            timeLabel = new Label();
            timeLabel.Text = "剩余时间：02:00";
            timeLabel.Font = new Font("Microsoft YaHei UI", 11F);
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(10, 10);
            timerPanel.Controls.Add(timeLabel);

            // 进度条
            progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 120;
            progressBar.Value = 120;
            progressBar.Width = 400;
            progressBar.Height = 20;
            progressBar.Location = new Point(10, 40);
            timerPanel.Controls.Add(progressBar);

            // 定位到右下角
            timerPanel.Left = this.ClientSize.Width - timerPanel.Width - 10;
            timerPanel.Top = this.ClientSize.Height - timerPanel.Height - 10;
            timerPanel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(timerPanel);
            timerPanel.BringToFront();

            // 启动Timer
            countdownSeconds = 120;
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;
            if (progressBar != null)
                progressBar.Value = countdownSeconds >= 0 ? countdownSeconds : 0;
            if (timeLabel != null)
                timeLabel.Text = $"剩余时间：{countdownSeconds / 60:D2}:{countdownSeconds % 60:D2}";

            if (countdownSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("时间到，答题结束！", "提示");
                this.Controls.Clear();
                if (timerPanel != null)
                {
                    this.Controls.Add(timerPanel);
                    timerPanel.BringToFront();
                }
            }
        }

        private void ShowQuestion(int index)
        {
            this.Controls.Clear();

            var q = questions[index];

            // 题目与选项
            Label questionLabel = new Label();
            questionLabel.Text = q.Text;
            questionLabel.AutoSize = true;
            questionLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F);
            questionLabel.Location = new System.Drawing.Point(50, 50);
            this.Controls.Add(questionLabel);

            RadioButton[] options = new RadioButton[q.Options.Length];
            for (int i = 0; i < q.Options.Length; i++)
            {
                options[i] = new RadioButton();
                options[i].Text = q.Options[i];
                options[i].AutoSize = true;
                options[i].Location = new System.Drawing.Point(70, 120 + i * 40);
                options[i].Name = $"option{i}";
                if (userAnswers[index] != -1 && userAnswers[index] == i)
                    options[i].Checked = true;
                this.Controls.Add(options[i]);
            }

            // 右侧题号与完成情况
            Panel statusPanel = new Panel();
            statusPanel.Width = 180;
            statusPanel.Height = 300;
            statusPanel.Location = new System.Drawing.Point(750, 50);
            statusPanel.BorderStyle = BorderStyle.FixedSingle;

            for (int i = 0; i < questions.Length; i++)
            {
                Label statusLabel = new Label();
                statusLabel.Text = $"第{i + 1}题：" + (userAnswers[i] != -1 ? "已完成" : "未完成");
                statusLabel.AutoSize = true;
                statusLabel.Location = new System.Drawing.Point(10, 10 + i * 40);
                statusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);

                // 高亮当前题号
                if (i == index)
                {
                    statusLabel.ForeColor = System.Drawing.Color.White;
                    statusLabel.BackColor = System.Drawing.Color.DodgerBlue;
                    statusLabel.Padding = new Padding(3);
                }
                // 设置可点击跳转
                statusLabel.Tag = i;
                statusLabel.Cursor = Cursors.Hand;
                statusLabel.Click += (s, e) =>
                {
                    SaveAnswer(index, options); // 先保存当前题目
                    int target = (int)((Label)s).Tag;
                    ShowQuestion(target);
                };

                statusPanel.Controls.Add(statusLabel);
            }
            this.Controls.Add(statusPanel);

            // 按钮
            if (index > 0)
            {
                Button prevButton = new Button();
                prevButton.Text = "上一题";
                prevButton.Size = new System.Drawing.Size(100, 40);
                prevButton.Location = new System.Drawing.Point(70, 120 + q.Options.Length * 40 + 20);
                prevButton.Click += (s, args) =>
                {
                    SaveAnswer(index, options);
                    ShowQuestion(index - 1);
                };
                this.Controls.Add(prevButton);
            }

            if (index < questions.Length - 1)
            {
                Button nextButton = new Button();
                nextButton.Text = "下一题";
                nextButton.Size = new System.Drawing.Size(100, 40);
                nextButton.Location = new System.Drawing.Point(200, 120 + q.Options.Length * 40 + 20);
                nextButton.Click += (s, args) =>
                {
                    SaveAnswer(index, options);
                    ShowQuestion(index + 1);
                };
                this.Controls.Add(nextButton);
            }
            else
            {
                Button submitButton = new Button();
                submitButton.Text = "提交";
                submitButton.Size = new System.Drawing.Size(100, 40);
                submitButton.Location = new System.Drawing.Point(200, 120 + q.Options.Length * 40 + 20);
                submitButton.Click += (s, args) =>
                {
                    SaveAnswer(index, options);

                    var missing = userAnswers
                        .Select((ans, idx) => new { ans, idx })
                        .Where(x => x.ans == -1)
                        .Select(x => (x.idx + 1).ToString())
                        .ToArray();

                    if (missing.Length > 0)
                    {
                        MessageBox.Show($"请旅行者完成以下题目再提交哦：{string.Join("，", missing)}", "提示");
                        return;
                    }

                    int correct = 0;
                    var wrongList = new System.Collections.Generic.List<int>();
                    for (int j = 0; j < questions.Length; j++)
                    {
                        if (userAnswers[j] == questions[j].CorrectIndex)
                            correct++;
                        else
                            wrongList.Add(j + 1);
                    }

                    string genshinMsg = correct switch
                    {
                        1 => "旅行者，你还需要多多修炼哦，继续加油吧！",
                        2 => "不错，已经掌握了一些原神知识，继续努力！",
                        3 => "很棒，看来你对提瓦特大陆有一定了解！",
                        4 => "优秀！你已经是原神的资深玩家了！",
                        5 => "完美！你就是提瓦特大陆的传说，真正的天命之人！",
                        _ => "旅行者，欢迎来到提瓦特大陆！"
                    };

                    string wrongMsg = wrongList.Count > 0
                        ? $"\n答错题号：{string.Join("，", wrongList)}"
                        : "";

                    MessageBox.Show($"答题完成！你共答对 {correct} 道题。{wrongMsg}\n{genshinMsg}", "结果");
                };
                this.Controls.Add(submitButton);
            }

            // 确保 timerPanel 始终在右下角
            if (timerPanel != null && !this.Controls.Contains(timerPanel))
            {
                this.Controls.Add(timerPanel);
                timerPanel.BringToFront();
            }
        }

        // 保存当前题目的答案
        private void SaveAnswer(int index, RadioButton[] options)
        {
            int selected = -1;
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].Checked)
                {
                    selected = i;
                    break;
                }
            }
            userAnswers[index] = selected;
        }
    }
}
