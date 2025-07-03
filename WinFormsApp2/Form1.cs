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
            // 直接指定贴吧名
            string university = "华东师范大学吧";
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

            using var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            
            using var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            client.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
            client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");

            while (crawled < postCount)
            {
                string url = $"https://tieba.baidu.com/f?kw={kw}&pn={page * 50}";
                try 
                {
                    string html = await client.GetStringAsync(url);
                    
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'threadlist_title')]/a");
                    if (nodes == null) break;

                    foreach (var node in nodes)
                    {
                        if (crawled >= postCount) break;
                        titles.Add(node.InnerText.Trim());
                        summaries.Add(node.GetAttributeValue("title", ""));
                        crawled++;
                        progress?.Report((int)((float)crawled / postCount * 100));
                    }
                    page++;
                    // 添加延时避免请求过快
                    await Task.Delay(Random.Shared.Next(1000, 2000));
                }
                catch (HttpRequestException ex)
                {
                    // 如果遇到错误，等待后重试
                    await Task.Delay(3000);
                    continue;
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
