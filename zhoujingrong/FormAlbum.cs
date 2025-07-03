using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace choices
{
    public partial class FormAlbum : Form
    {
        private int currentPhotoIndex = -1; // 当前照片索引
        private int currentAlbumIndex = -1; // 当前相册索引



        public FormAlbum()
        {

            InitializeComponent();
            LoadAlbums();
        }

        private void LoadAlbums()
        {
            // 清空相册下拉菜单
            comboBoxAlbum.Items.Clear();

            // 添加相册到下拉菜单
            foreach (var album in ImageViewer.AlbumData.AllAlbums)
            {
                comboBoxAlbum.Items.Add(album.Name);
            }
        }

        private void comboBoxAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlbum.SelectedIndex >= 0)
            {
                // 获取选中的相册
                currentAlbumIndex = comboBoxAlbum.SelectedIndex;
                var selectedAlbum = ImageViewer.AlbumData.AllAlbums[currentAlbumIndex];

                // 清空照片下拉菜单
                comboBoxPhoto.Items.Clear();

                // 添加照片到下拉菜单
                foreach (var photo in selectedAlbum.Photos)
                {
                    comboBoxPhoto.Items.Add(photo.Title);
                }

                // 启用照片下拉菜单和导航按钮
                comboBoxPhoto.Enabled = true;
                UpdateNavigationButtons();

                // 清空当前显示的图片和描述
                pictureBox1.Image = null;
                labelDescription.Text = "你还没有选择照片！";
                currentPhotoIndex = -1;
                progressBar1.Value = 0;
                labelIndex.Visible = false;

                //修改进度条上限
                progressBar1.Maximum = selectedAlbum.Photos.Count;
            }
        }

        private void comboBoxPhoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPhoto.SelectedIndex >= 0 && comboBoxAlbum.SelectedIndex >= 0)
            {
                currentPhotoIndex = comboBoxPhoto.SelectedIndex;
                ShowCurrentPhoto();
                UpdateNavigationButtons();
            }
        }

        private void ShowCurrentPhoto()
        {
            if (currentAlbumIndex >= 0 && currentPhotoIndex >= 0)
            {
                // 获取选中的相册和照片
                var selectedAlbum = ImageViewer.AlbumData.AllAlbums[currentAlbumIndex];
                var selectedPhoto = selectedAlbum.Photos[currentPhotoIndex];

                //进度条进度
                progressBar1.Value = currentPhotoIndex + 1;
                progressBar1.Refresh();

                //索引修改
                labelIndex.Text = $"{currentPhotoIndex + 1}/{selectedAlbum.Photos.Count}";
                labelIndex.Visible = true;

                // 加载并显示图片
                LoadImage(selectedPhoto.ImagePath, selectedPhoto.Description);

                // 同步下拉菜单的选择
                comboBoxPhoto.SelectedIndex = currentPhotoIndex;
            }
        }

        private void UpdateNavigationButtons()
        {
            // 只有选择了相册且有照片时才启用按钮
            bool hasPhotos = currentAlbumIndex >= 0 &&
                           ImageViewer.AlbumData.AllAlbums[currentAlbumIndex].Photos.Count > 0;


            if (this.Controls.ContainsKey("buttonPrevious"))
            {
                this.Controls["buttonPrevious"].Enabled = hasPhotos;
            }
            if (this.Controls.ContainsKey("buttonNext"))
            {
                this.Controls["buttonNext"].Enabled = hasPhotos;
            }
        }

        // 上一张照片按钮点击事件
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentAlbumIndex >= 0)
            {
                var currentAlbum = ImageViewer.AlbumData.AllAlbums[currentAlbumIndex];
                if (currentAlbum.Photos.Count > 0)
                {
                    // 如果没有选择照片，从最后一张开始
                    if (currentPhotoIndex < 0)
                    {
                        currentPhotoIndex = currentAlbum.Photos.Count - 1;
                    }
                    else
                    {
                        // 上一张，如果到头就循环到最后一张
                        currentPhotoIndex--;
                        if (currentPhotoIndex < 0)
                        {
                            currentPhotoIndex = currentAlbum.Photos.Count - 1;
                        }
                    }
                    ShowCurrentPhoto();
                }
            }
        }



        // 下一张照片按钮点击事件
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentAlbumIndex >= 0)
            {
                var currentAlbum = ImageViewer.AlbumData.AllAlbums[currentAlbumIndex];
                if (currentAlbum.Photos.Count > 0)
                {
                    // 如果没有选择照片，从第一张开始
                    if (currentPhotoIndex < 0)
                    {
                        currentPhotoIndex = 0;
                    }
                    else
                    {
                        // 下一张，如果到头就循环到第一张
                        currentPhotoIndex++;
                        if (currentPhotoIndex >= currentAlbum.Photos.Count)
                        {
                            currentPhotoIndex = 0;
                        }
                    }
                    ShowCurrentPhoto();
                }
            }
        }

        //照片点击事件
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // e.X 是鼠标点击的横坐标，相对于 pictureBox 左上角
            int halfWidth = pictureBox1.Width / 2;

            if (e.X > halfWidth)
            {
                // 右半边，调用下一张按钮事件
                buttonNext_Click(buttonNext, EventArgs.Empty);
            }
            else
            {
                // 左半边，调用上一张按钮事件（假如有）
                buttonPrevious_Click(buttonPrevious, EventArgs.Empty);
            }
        }


        private void LoadImage(string imagePath, string description)
        {
            try
            {
                // 检查文件是否存在
                if (File.Exists(imagePath))
                {
                    // 使用FileStream来读取图片，避免文件锁定
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                    }
                    labelDescription.Text = description;
                }
                else
                {
                    // 如果文件不存在，显示错误信息
                    pictureBox1.Image = null;
                    labelDescription.Text = $"图片文件未找到: {imagePath}";
                    MessageBox.Show($"图片文件未找到: {imagePath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
                labelDescription.Text = "加载图片时出现错误";
                MessageBox.Show($"加载图片时出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAlbum_Load(object sender, EventArgs e)
        {
            // 窗体加载时的初始化
        }

        // 重写Dispose方法以确保图片资源被正确释放
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pictureBox1?.Image?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonNext_Click(buttonNext, EventArgs.Empty);
        }

        private void checkBoxSlide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSlide.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void textBox1_Validating(object sender, EventArgs e)
        {
            // 尝试将文本框中的内容转换为整数
            if (float.TryParse(textBox1.Text, out float interval))
            {
                // 判断是否为合法的正数（Timer.Interval 要求 > 0）
                if (interval > 0)
                {
                    timer1.Interval = (int)(interval * 1000);
                }
                else
                {
                    // 非法：非正数
                    MessageBox.Show("请输入一个大于 0 的整数作为间隔时间", "非法输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // 非法：无法解析为整数
                if (!string.IsNullOrWhiteSpace(textBox1.Text)) // 避免空文本反复提示
                {
                    MessageBox.Show("请输入合法的数字", "非法输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // 假设你用于显示图片的是 pictureBoxMain
            {
                Form fullscreenForm = new Form();

                // 设置为无边框全屏
                fullscreenForm.FormBorderStyle = FormBorderStyle.None;
                fullscreenForm.WindowState = FormWindowState.Maximized;
                fullscreenForm.BackColor = Color.Black;
                fullscreenForm.StartPosition = FormStartPosition.CenterScreen;

                // 创建 PictureBox 并全屏显示图片
                PictureBox fullscreenPictureBox = new PictureBox();
                fullscreenPictureBox.Dock = DockStyle.Fill;
                fullscreenPictureBox.Image = pictureBox1.Image;
                fullscreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                fullscreenPictureBox.BackColor = Color.Black;

                // 点击全屏图片退出全屏
                fullscreenPictureBox.Click += (s, args) => fullscreenForm.Close();

                fullscreenForm.Controls.Add(fullscreenPictureBox);
                fullscreenForm.ShowDialog(); // 模态显示
            }
        }
    }
}