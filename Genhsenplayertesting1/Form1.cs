using System;
using System.Linq;
using System.Windows.Forms; // ȷ����ȷʹ�� System.Windows.Forms.Timer

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

        // ���
        private readonly Question[] questions = new Question[]
        {
            new Question { Text = "��1�⣺������λ��ɫ����ԭ���еĽ�ɫ��", Options = new[] { "��", "��¬��", "�����" }, CorrectIndex = 2 },
            new Question { Text = "��2�⣺��������Ԫ�ز�������ԭ��", Options = new[] { "��", "ˮ", "��" }, CorrectIndex = 2 },
            new Question { Text = "��3�⣺������λ��ɫ�����¸۵�����֮һ��", Options = new[] { "����", "����", "�Ű���" }, CorrectIndex = 0 },
            new Question { Text = "��4�⣺���������������Ͳ���ԭ���еģ�", Options = new[] { "����", "��", "˫�ֽ�" }, CorrectIndex = 0 },
            new Question { Text = "��5�⣺������λ��ɫ��Ԫ�������Ǳ���", Options = new[] { "����", "����", "����" }, CorrectIndex = 0 }
        };

        private int currentQuestion = 0;
        private int[] userAnswers = new int[5];

        private System.Windows.Forms.Timer countdownTimer; // ��ȷָ�� Timer �������ռ�
        private int countdownSeconds = 120; // 2����
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
            // ��ʾ����ʱ�ͽ�����
            StartCountdown();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�����ߣ��ڴ�����׼���ú����μӲ��ԣ�", "��ʾ");
        }

        private void StartCountdown()
        {
            // ��ʼ������״̬
            currentQuestion = 0;
            userAnswers = Enumerable.Repeat(-1, questions.Length).ToArray();

            // ��ʾ��һ��
            ShowQuestion(currentQuestion);

            // �������½Ƕ�ʱ�����
            if (timerPanel != null && this.Controls.Contains(timerPanel))
                this.Controls.Remove(timerPanel);

            timerPanel = new Panel();
            timerPanel.Width = 420;
            timerPanel.Height = 70;
            timerPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            timerPanel.BorderStyle = BorderStyle.FixedSingle;

            // ����ʱLabel
            timeLabel = new Label();
            timeLabel.Text = "ʣ��ʱ�䣺02:00";
            timeLabel.Font = new Font("Microsoft YaHei UI", 11F);
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(10, 10);
            timerPanel.Controls.Add(timeLabel);

            // ������
            progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 120;
            progressBar.Value = 120;
            progressBar.Width = 400;
            progressBar.Height = 20;
            progressBar.Location = new Point(10, 40);
            timerPanel.Controls.Add(progressBar);

            // ��λ�����½�
            timerPanel.Left = this.ClientSize.Width - timerPanel.Width - 10;
            timerPanel.Top = this.ClientSize.Height - timerPanel.Height - 10;
            timerPanel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(timerPanel);
            timerPanel.BringToFront();

            // ����Timer
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
                timeLabel.Text = $"ʣ��ʱ�䣺{countdownSeconds / 60:D2}:{countdownSeconds % 60:D2}";

            if (countdownSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("ʱ�䵽�����������", "��ʾ");
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

            // ��Ŀ��ѡ��
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

            // �Ҳ������������
            Panel statusPanel = new Panel();
            statusPanel.Width = 180;
            statusPanel.Height = 300;
            statusPanel.Location = new System.Drawing.Point(750, 50);
            statusPanel.BorderStyle = BorderStyle.FixedSingle;

            for (int i = 0; i < questions.Length; i++)
            {
                Label statusLabel = new Label();
                statusLabel.Text = $"��{i + 1}�⣺" + (userAnswers[i] != -1 ? "�����" : "δ���");
                statusLabel.AutoSize = true;
                statusLabel.Location = new System.Drawing.Point(10, 10 + i * 40);
                statusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);

                // ������ǰ���
                if (i == index)
                {
                    statusLabel.ForeColor = System.Drawing.Color.White;
                    statusLabel.BackColor = System.Drawing.Color.DodgerBlue;
                    statusLabel.Padding = new Padding(3);
                }
                // ���ÿɵ����ת
                statusLabel.Tag = i;
                statusLabel.Cursor = Cursors.Hand;
                statusLabel.Click += (s, e) =>
                {
                    SaveAnswer(index, options); // �ȱ��浱ǰ��Ŀ
                    int target = (int)((Label)s).Tag;
                    ShowQuestion(target);
                };

                statusPanel.Controls.Add(statusLabel);
            }
            this.Controls.Add(statusPanel);

            // ��ť
            if (index > 0)
            {
                Button prevButton = new Button();
                prevButton.Text = "��һ��";
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
                nextButton.Text = "��һ��";
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
                submitButton.Text = "�ύ";
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
                        MessageBox.Show($"�����������������Ŀ���ύŶ��{string.Join("��", missing)}", "��ʾ");
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
                        1 => "�����ߣ��㻹��Ҫ�������Ŷ���������Ͱɣ�",
                        2 => "�����Ѿ�������һЩԭ��֪ʶ������Ŭ����",
                        3 => "�ܰ���������������ش�½��һ���˽⣡",
                        4 => "���㣡���Ѿ���ԭ�����������ˣ�",
                        5 => "����������������ش�½�Ĵ�˵������������֮�ˣ�",
                        _ => "�����ߣ���ӭ���������ش�½��"
                    };

                    string wrongMsg = wrongList.Count > 0
                        ? $"\n�����ţ�{string.Join("��", wrongList)}"
                        : "";

                    MessageBox.Show($"������ɣ��㹲��� {correct} ���⡣{wrongMsg}\n{genshinMsg}", "���");
                };
                this.Controls.Add(submitButton);
            }

            // ȷ�� timerPanel ʼ�������½�
            if (timerPanel != null && !this.Controls.Contains(timerPanel))
            {
                this.Controls.Add(timerPanel);
                timerPanel.BringToFront();
            }
        }

        // ���浱ǰ��Ŀ�Ĵ�
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
