using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace ElectronicAlbum
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.ComboBox cmbBigGroup;
        private System.Windows.Forms.ComboBox cmbSmallGroup;
        private Button btnPlayAudio;
        private Button btnStopAudio; 

        private SoundPlayer currentPlayer;

        private readonly string[] imagePaths = { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg", "7.jpg", "8.jpg", "9.jpg", "10.jpg", "11.jpg", "12.jpg" };
        private readonly string[] imageDescriptions = { "����������֦ͷ", "���������ڻ���", "��������������", "�龱���������", "�龱����ڲ�ƺ", "�龱������ּ�", "��ͷ�������±�", "��ͷ�����ڷ���", "��ͷ����������", "�����ڵ��߸�", "���������", "����������" };
        private readonly (int start, int end)[] bigGroups = { (0, 5), (6, 11) };
        private readonly (int start, int end)[] smallGroups = { (0, 2), (3, 5), (6, 8), (9, 11) };
        private int currentIndex = 0;

        private readonly (int start, int end, string name, (int start, int end, string name)[] subGroups)[] groupHierarchy = new[]
        {
            (0, 5, "����", new[] { (0, 2, "��������"), (3, 5, "�龱���") }),
            (6, 11, "����", new[] { (6, 8, "��ͷ����"), (9, 11, "����") })
        };

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            ShowImage(0);

            // 
            // cmbBigGroup
            // 
            cmbBigGroup = new ComboBox();
            cmbBigGroup.Location = new Point(500, 100);
            cmbBigGroup.Name = "cmbBigGroup";
            cmbBigGroup.Size = new Size(200, 30);
            cmbBigGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBigGroup.SelectedIndexChanged += cmbBigGroup_SelectedIndexChanged;
            Controls.Add(cmbBigGroup);
            // 
            // cmbSmallGroup
            // 
            cmbSmallGroup = new ComboBox();
            cmbSmallGroup.Location = new Point(500, 150);
            cmbSmallGroup.Name = "cmbSmallGroup";
            cmbSmallGroup.Size = new Size(200, 30);
            cmbSmallGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSmallGroup.SelectedIndexChanged += cmbSmallGroup_SelectedIndexChanged;
            Controls.Add(cmbSmallGroup);

            progressBar.Minimum = 0;
            progressBar.Maximum = imagePaths.Length - 1;
            progressBar.Value = 0;      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ��ʼ������������
            cmbBigGroup.Items.Clear();
            foreach (var group in groupHierarchy)
                cmbBigGroup.Items.Add(group.name);
            if (cmbBigGroup.Items.Count > 0)
                cmbBigGroup.SelectedIndex = 0;

            progressBar.Minimum = 0;
            progressBar.Maximum = imagePaths.Length - 1;
            progressBar.Value = 0;
        }

        private void ShowImage(int index)
        {
            if (index >= 0 && index < imagePaths.Length)
            {
                string imagePath = imagePaths[index];
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    lblDescription.Text = imageDescriptions[index];
                    progressBar.Minimum = 0;
                    progressBar.Maximum = imagePaths.Length - 1;
                    progressBar.Value = index;
                    currentIndex = index;

                    // ����ҳ����Ϣ
                    lblPageInfo.Text = $"�� {index + 1} �ţ��� {imagePaths.Length} ��";
                }
                else
                {
                    MessageBox.Show($"Image file not found: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetCurrentIndex(int index)
        {
            if (index < 0 || index >= imagePaths.Length)
                return;

            // 1. ��ʾͼƬ
            ShowImage(index);

            // 2. ͬ�����顢С��������
            for (int bigIdx = 0; bigIdx < groupHierarchy.Length; bigIdx++)
            {
                var group = groupHierarchy[bigIdx];
                if (index >= group.start && index <= group.end)
                {
                    if (cmbBigGroup.SelectedIndex != bigIdx)
                        cmbBigGroup.SelectedIndex = bigIdx;

                    // ����С��
                    for (int smallIdx = 0; smallIdx < group.subGroups.Length; smallIdx++)
                    {
                        var sub = group.subGroups[smallIdx];
                        if (index >= sub.start && index <= sub.end)
                        {
                            if (cmbSmallGroup.SelectedIndex != smallIdx)
                                cmbSmallGroup.SelectedIndex = smallIdx;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPage.Text, out int page) && page >= 1 && page <= imagePaths.Length)
            {
                SetCurrentIndex(page - 1);
            }
        }

        private void chkSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            slideShowTimer.Enabled = chkSlideShow.Checked;
        }

        private void slideShowTimer_Tick(object sender, EventArgs e)
        {
            SetCurrentIndex((currentIndex + 1) % imagePaths.Length);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < pictureBox1.Width / 2)
            {
                Cursor = Cursors.PanWest;
            }
            else
            {
                Cursor = Cursors.PanEast;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < pictureBox1.Width / 2)
            {
                SetCurrentIndex((currentIndex - 1 + imagePaths.Length) % imagePaths.Length);
            }
            else
            {
                SetCurrentIndex((currentIndex + 1) % imagePaths.Length);
            }
        }

        private void cmbBigGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �л�����ʱ��ˢ��С��������
            int bigIdx = cmbBigGroup.SelectedIndex;
            cmbSmallGroup.Items.Clear();
            if (bigIdx >= 0 && bigIdx < groupHierarchy.Length)
            {
                foreach (var sub in groupHierarchy[bigIdx].subGroups)
                    cmbSmallGroup.Items.Add(sub.name);
                if (cmbSmallGroup.Items.Count > 0)
                    cmbSmallGroup.SelectedIndex = 0;
            }
        }

        private void cmbSmallGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bigIdx = cmbBigGroup.SelectedIndex;
            int smallIdx = cmbSmallGroup.SelectedIndex;
            if (bigIdx >= 0 && smallIdx >= 0)
            {
                var sub = groupHierarchy[bigIdx].subGroups[smallIdx];
                SetCurrentIndex(sub.start);

                // ��̬��Ӳ��Ű�ť
                if (btnPlayAudio != null)
                {
                    Controls.Remove(btnPlayAudio);
                    btnPlayAudio.Dispose();
                }
                btnPlayAudio = new Button();
                btnPlayAudio.Location = new Point(500, 200);
                btnPlayAudio.Size = new Size(95, 30);
                btnPlayAudio.Text = $"������Ƶ";
                btnPlayAudio.Click += (s, args) => PlayAudio(sub.name);
                Controls.Add(btnPlayAudio);

                // ��̬���ֹͣ��ť
                if (btnStopAudio != null)
                {
                    Controls.Remove(btnStopAudio);
                    btnStopAudio.Dispose();
                }
                btnStopAudio = new Button();
                btnStopAudio.Location = new Point(605, 200);
                btnStopAudio.Size = new Size(95, 30);
                btnStopAudio.Text = "ֹͣ��Ƶ";
                btnStopAudio.Click += (s, args) => StopAudio();
                Controls.Add(btnStopAudio);
            }
        }

        private void PlayAudio(string groupName)
        {
            string audioFilePath = $"{groupName}.wav";
            if (System.IO.File.Exists(audioFilePath))
            {
                StopAudio(); // ����ǰ��ֹͣ��һ��
                currentPlayer = new SoundPlayer(audioFilePath);
                currentPlayer.Play();
            }
            else
            {
                MessageBox.Show($"��Ƶ�ļ�δ�ҵ�: {audioFilePath}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopAudio()
        {
            if (currentPlayer != null)
            {
                currentPlayer.Stop();
                currentPlayer.Dispose();
                currentPlayer = null;
            }
        }
    }
}