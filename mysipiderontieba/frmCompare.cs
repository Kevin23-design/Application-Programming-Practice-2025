using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace choices
{
    public partial class frmCompare : Form
    {
        public frmCompare()
        {
            InitializeComponent();
        }

        private async void btnStartCompare_Click(object sender, EventArgs e)
        {
            string tieba1 = txtTieba1.Text.Trim();
            string tieba2 = txtTieba2.Text.Trim();
            string hotWord = txtHotWord.Text.Trim();
            if (string.IsNullOrEmpty(tieba1) || string.IsNullOrEmpty(tieba2) || string.IsNullOrEmpty(hotWord))
            {
                MessageBox.Show("请输入两个贴吧名称和热词");
                return;
            }



            btnStartCompare.Enabled = false;
            lblResult.Text = "正在抓取数据，请稍候...";
            pictureBoxThumb.Visible = false;

            int pages = (int)numPages.Value;
            int hotWordCount = 10;
            try
            {
                var posts1 = await CrawlTiebaPosts(tieba1, pages);
                var posts2 = await CrawlTiebaPosts(tieba2, pages);

                int sum1 = CalcCustomHotWordsScore(posts1, hotWordCount, hotWord);
                int sum2 = CalcCustomHotWordsScore(posts2, hotWordCount, hotWord);

                string winner = null;
                string compareText = $"【{tieba1}】含\"{hotWord}\"热词关注度：{sum1}\r\n【{tieba2}】含\"{hotWord}\"热词关注度：{sum2}\r\n";
                if (sum1 > sum2)
                    winner = tieba1;
                else if (sum2 > sum1)
                    winner = tieba2;

                if (winner != null)
                {
                    lblResult.Text = compareText +
                        $"恭喜\"{winner}\"吧，你的含{hotWord}量更高！真厉害！";
                    try
                    {
                        pictureBoxThumb.Image = Image.FromFile("thumbs-up.png");
                        pictureBoxThumb.Visible = true;
                    }
                    catch
                    {
                        pictureBoxThumb.Visible = false;
                    }
                }
                else
                {
                    lblResult.Text = compareText + $"两个贴吧含\"{hotWord}\"热词关注度之和相等！";
                    pictureBoxThumb.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "对比失败：" + ex.Message;
                pictureBoxThumb.Visible = false;
            }
            finally
            {
                btnStartCompare.Enabled = true;
            }
        }

        private void numPages_ValueChanged(object sender, EventArgs e)
        {
            // 在此处添加处理逻辑，例如更新界面或处理用户输入
            lblResult.Text = $"当前选择的页数: {numPages.Value}";
        }

        private int CalcCustomHotWordsScore(List<PostInfo> posts, int hotWordCount, string hotWord)
        {
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
                .Where(x => x.Key.Contains(hotWord))
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

            return hotWords.Sum(x => x.关注度);
        }

        private async Task<List<PostInfo>> CrawlTiebaPosts(string tiebaName, int pages)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            var posts = new List<PostInfo>();
            for (int i = 0; i < pages; i++)
            {
                int pn = i * 50;
                string url = $"https://tieba.baidu.com/f?kw={tiebaName}&pn={pn}";
                string html = await httpClient.GetStringAsync(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var threadItems = doc.DocumentNode.SelectNodes("//li[contains(@class, 'j_thread_list')]");
                if (threadItems == null) continue;

                foreach (var item in threadItems)
                {
                    var titleNode = item.SelectSingleNode(".//a[contains(@class,");
                }
            }
            return posts;
        }
    }
}