using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;

namespace choices
{
    public partial class frmSpider : Form
    {
        private readonly HttpClient _httpClient;
        private List<PostInfo> _allPosts; // 用于热词点击时筛选帖子

        public frmSpider()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        }

        private async void btnCrawl_Click(object sender, EventArgs e)
        {
            string tiebaName = txtTiebaName.Text.Trim();
            if (string.IsNullOrEmpty(tiebaName))
            {
                MessageBox.Show("请输入贴吧名称");
                return;
            }

            int pages = (int)numPages.Value;
            if (pages <= 0)
            {
                MessageBox.Show("请设置有效的页数");
                return;
            }

            btnCrawl.Enabled = false;
            progressBar1.Maximum = pages;
            progressBar1.Value = 0;

            try
            {
                List<PostInfo> posts = new List<PostInfo>();

                for (int i = 0; i < pages; i++)
                {
                    int pn = i * 50; // 贴吧每页50条帖子
                    string url = $"https://tieba.baidu.com/f?kw={tiebaName}&pn={pn}";

                    var pagePosts = await CrawlPageAsync(url);
                    posts.AddRange(pagePosts);

                    progressBar1.Value = i + 1;
                    await Task.Delay(1000); // 延迟防止被封
                }

                DisplayResults(posts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"爬取失败: {ex.Message}");
            }
            finally
            {
                btnCrawl.Enabled = true;
            }
        }

        private async Task<List<PostInfo>> CrawlPageAsync(string url)
        {
            List<PostInfo> posts = new List<PostInfo>();

            try
            {
                string html = await _httpClient.GetStringAsync(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var threadItems = doc.DocumentNode.SelectNodes("//li[contains(@class, 'j_thread_list')]");
                if (threadItems == null) return posts;

                foreach (var item in threadItems)
                {
                    var titleNode = item.SelectSingleNode(".//a[contains(@class, 'j_th_tit')]");
                    var authorNode = item.SelectSingleNode(".//span[contains(@class, 'tb_icon_author')]");
                    var replyNode = item.SelectSingleNode(".//span[contains(@class, 'threadlist_rep_num')]");

                    if (titleNode != null && authorNode != null)
                    {
                        string title = titleNode.InnerText.Trim();
                        string author = authorNode.Attributes["title"]?.Value.Replace("主题作者: ", "");
                        string replyCount = replyNode?.InnerText.Trim() ?? "0";
                        string href = "https://tieba.baidu.com" + titleNode.Attributes["href"]?.Value;

                        posts.Add(new PostInfo
                        {
                            Title = title,
                            Author = author,
                            ReplyCount = replyCount,
                            Url = href
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解析页面出错: {ex.Message}");
            }

            return posts;
        }

        private void DisplayResults(List<PostInfo> posts)
        {
            _allPosts = posts; // 保存所有帖子

            // 显示帖子列表到 dataGridView1
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = posts;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.CellContentClick += (s, e) =>
            {
                if (e.ColumnIndex == dataGridView1.Columns["Url"].Index && e.RowIndex >= 0)
                {
                    string url = dataGridView1.Rows[e.RowIndex].Cells["Url"].Value.ToString();
                    System.Diagnostics.Process.Start(url);
                }
            };

            // 获取热词个数
            int hotWordCount = 10;
            if (numericUpDown1 != null)
                hotWordCount = (int)numericUpDown1.Value;

            // 计算热词关注度
            var wordStats = new Dictionary<string, (int postCount, int replySum)>();
            foreach (var post in posts)
            {
                var words = post.Title.Split(new[] { ' ', '，', '。', '！', '？', '、', ',', '.', '!', '?', '[', ']', '【', '】' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word.Length < 2) continue;
                    if (!wordStats.ContainsKey(word))
                        wordStats[word] = (0, 0);
                    wordStats[word] = (wordStats[word].postCount + 1, wordStats[word].replySum + int.Parse(post.ReplyCount));
                }
            }
            var hotWords = wordStats
                .Select(x => new
                {
                    关键词 = x.Key,
                    帖子数 = x.Value.postCount,
                    回帖总数 = x.Value.replySum,
                    关注度 = x.Value.postCount * x.Value.replySum
                })
                .OrderByDescending(x => x.关注度)
                .Take(hotWordCount)
                .ToList();

            // 创建数据源
            var hotWordsTable = new DataTable();
            hotWordsTable.Columns.Add("关键词", typeof(string));
            hotWordsTable.Columns.Add("帖子数", typeof(int));
            hotWordsTable.Columns.Add("回帖总数", typeof(int));
            hotWordsTable.Columns.Add("关注度", typeof(int));

            foreach (var word in hotWords)
            {
                hotWordsTable.Rows.Add(word.关键词, word.帖子数, word.回帖总数, word.关注度);
            }

            dataGridView2.DataSource = hotWordsTable;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "关键词")
            {
                string keyword = dataGridView2.Rows[e.RowIndex].Cells["关键词"].Value.ToString();
                var filtered = _allPosts.Where(p => p.Title.Contains(keyword)).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filtered;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_allPosts != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _allPosts;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        public class PostInfo
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ReplyCount { get; set; }
            public string Url { get; set; }
        }

        private void frmSpider_Load(object sender, EventArgs e)
        {

        }

        private void numPages_ValueChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTiebaName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
