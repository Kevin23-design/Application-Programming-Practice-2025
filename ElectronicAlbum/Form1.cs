using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElectronicAlbum
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.ComboBox cmbBigGroup;
        private System.Windows.Forms.ComboBox cmbSmallGroup;

        private readonly string[] imagePaths = { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg", "7.jpg", "8.jpg", "9.jpg", "10.jpg", "11.jpg", "12.jpg" };
        private readonly string[] imageDescriptions = { "鹦鹉在枝头", "鹦鹉在花间", "鹦鹉在天空", "朱颈斑鸠在屋檐", "朱颈斑鸠在草坪", "朱颈斑鸠在林间", "白头鹰在崖壁", "白头鹰在飞翔", "白头鹰在狩猎", "游隼在电线杆", "游隼在天空", "游隼在狩猎" };
        private readonly (int start, int end)[] bigGroups = { (0, 5), (6, 11) };
        private readonly (int start, int end)[] smallGroups = { (0, 2), (3, 5), (6, 8), (9, 11) };
        private int currentIndex = 0;

        // 分级分组结构
        private readonly (int start, int end, string name, (int start, int end, string name)[] subGroups)[] groupHierarchy = new[]
        {
            (0, 5, "林鸟", new[] { (0, 2, "鹦鹉"), (3, 5, "朱颈斑鸠") }),
            (6, 11, "猛禽", new[] { (6, 8, "白头鹰"), (9, 11, "游隼") })
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
            // 初始化大组下拉框
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
                }
                else
                {
                    MessageBox.Show($"Image file not found: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPage.Text, out int page) && page >= 1 && page <= imagePaths.Length)
            {
                ShowImage(page - 1);
            }
        }

        private void chkSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            slideShowTimer.Enabled = chkSlideShow.Checked;
        }

        private void slideShowTimer_Tick(object sender, EventArgs e)
        {
            ShowImage((currentIndex + 1) % imagePaths.Length);
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
                ShowImage((currentIndex - 1 + imagePaths.Length) % imagePaths.Length);
            }
            else
            {
                ShowImage((currentIndex + 1) % imagePaths.Length);
            }
        }

        private void cmbBigGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 切换大组时，刷新小组下拉框
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
            // 选择小组时跳转
            int bigIdx = cmbBigGroup.SelectedIndex;
            int smallIdx = cmbSmallGroup.SelectedIndex;
            if (bigIdx >= 0 && smallIdx >= 0)
            {
                var sub = groupHierarchy[bigIdx].subGroups[smallIdx];
                ShowImage(sub.start);
            }
        }
    }
}
   