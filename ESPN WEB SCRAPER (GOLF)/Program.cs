
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var html = await GetHtml();
            var data = ParseHtmlUsingHtmlAgilityPack(html);
        }

        private static Task<string> GetHtml()
        {
            var client = new HttpClient();
            return client.GetStringAsync("https://www.espn.com/golf/rankings");
        }

        private static List<(string RepositoryName, string Description)> ParseHtmlUsingHtmlAgilityPack(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var repositories =
                htmlDoc
                    .DocumentNode
                    .SelectNodes("//div[@class='ResponsiveTable ResponsiveTable--fixed-left']/div/table/tbody/tr");

            List<(string RepositoryName, string Description)> data = new();

            foreach (var repo in repositories)
            {
                var name = repo.SelectSingleNode("td/div/a").InnerText;
                var description = repo.SelectSingleNode("td/span").InnerText;
                data.Add((name, description));
                Console.WriteLine(name + description);
            }

            return data;
        }
    }
}