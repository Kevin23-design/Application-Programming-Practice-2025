using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string university = txtUniversity.Text.Trim();
            int postCount = (int)numPostCount.Value;
            progressBar.Value = 0;
            lstTitles.Items.Clear();
            txtKeywords.Clear();

            var (titles, summaries) = await CrawlTiebaAsync(university, postCount, new Progress<int>(value =>
            {
                progressBar.Value = value;
            }));

            foreach (var title in titles)
                lstTitles.Items.Add(title);

            var keywords = GetTopKeywords(titles.Concat(summaries), 10);
            txtKeywords.Text = string.Join(Environment.NewLine, keywords.Select(k => $"{k.Word}: {k.Count}"));
        }

        private async Task<(List<string> Titles, List<string> Summaries)> CrawlTiebaAsync(string university, int postCount, IProgress<int> progress)
        {
            var titles = new List<string>();
            var summaries = new List<string>();
            int page = 0, crawled = 0;
            string kw = Uri.EscapeDataString(university);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
            client.DefaultRequestHeaders.Add("Referer", "https://tieba.baidu.com/");

            while (crawled < postCount)
            {
                string url = $"https://tieba.baidu.com/f?kw={kw}&pn={page * 50}";
                string html = await client.GetStringAsync(url);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument(); // 修复：明确指定命名空间
                doc.LoadHtml(html);

                var nodes = doc.DocumentNode.SelectNodes("//li[contains(@class,'j_thread_list')]");
                if (nodes == null) break;

                foreach (var node in nodes)
                {
                    if (crawled >= postCount) break;
                    var titleNode = node.SelectSingleNode(".");
                }
            }

            return (titles, summaries);
        }

        private List<(string Word, int Count)> GetTopKeywords(IEnumerable<string> texts, int topCount)
        {
            var wordFrequency = new Dictionary<string, int>();

            foreach (var text in texts)
            {
                var words = text.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (wordFrequency.ContainsKey(word))
                        wordFrequency[word]++;
                    else
                        wordFrequency[word] = 1;
                }
            }

            return wordFrequency
                .OrderByDescending(kvp => kvp.Value)
                .Take(topCount)
                .Select(kvp => (kvp.Key, kvp.Value))
                .ToList();
        }
    }
}
