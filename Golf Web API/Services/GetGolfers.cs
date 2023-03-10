using Golf_Web_API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Golf_Web_API.Services.Interfaces;

namespace Golf_Web_API.Services
{
    public class GetGolfers : IGetGolfers
    {
        public async Task<List<GolfPlayer>> scrapeForGolfers()
        {
            string html = await GetHtml();
            List<GolfPlayer> data = ParseHtmlUsingHtmlAgilityPack(html);
            return data.ToList();
        }

        private static Task<string> GetHtml()
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync("https://www.espn.com/golf/rankings");
        }

        private static List<GolfPlayer> ParseHtmlUsingHtmlAgilityPack(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection repositories =
                htmlDoc
                    .DocumentNode
                    .SelectNodes("//div[@class='ResponsiveTable ResponsiveTable--fixed-left']/div/table/tbody/tr");

            List<GolfPlayer> data = new();

            foreach (HtmlNode repo in repositories)
            {
                GolfPlayer player = new GolfPlayer();
                string name = repo.SelectSingleNode("td/div/a").InnerText;
                int rank = Int32.Parse(repo.SelectSingleNode("td/span").InnerText);
                player.name = name;
                player.rank = rank;
                data.Add(player);
            }
            return data;
        }
    }
}
