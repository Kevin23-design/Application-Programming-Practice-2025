using System;
using System.Windows.Forms;
using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;

namespace fenci
{
    public partial class Form1 : Form
    {
        // 确保定义了 txtInput 和 lstNames 控件
        private TextBox txtInput;
        private ListBox lstNames;
        private Button btnRecognize;

        public Form1()
        {
            InitializeComponent();

            // 初始化控件
            txtInput = new TextBox { Location = new System.Drawing.Point(10, 10), Width = 200 };
            lstNames = new ListBox { Location = new System.Drawing.Point(10, 50), Width = 200, Height = 100 };
            btnRecognize = new Button { Location = new System.Drawing.Point(10, 160), Text = "识别" };

            btnRecognize.Click += btnRecognize_Click;

            // 将控件添加到窗体
            Controls.Add(txtInput);
            Controls.Add(lstNames);
            Controls.Add(btnRecognize);
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            var text = txtInput.Text.Trim();
            var posSeg = new PosSegmenter();
            var tokens = posSeg.Cut(text);

            lstNames.Items.Clear();
            foreach (var token in tokens)
            {
                // nr 是人名的词性标记
                if (token.Flag == "nr")
                {
                    lstNames.Items.Add(token.Word);
                }
            }
        }
    }
}
