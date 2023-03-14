using Golf_Web_API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Golf_Web_API.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Golf_Web_API.Services
{
    public class GetGolfers : IGetGolfers
    {
        public async Task<List<GolfPlayer>> scrapeForGolfers(int pageNumber)
        {
            string htmlFromESPN = await GetHtml();
            List<GolfPlayer> data = ParseHtmlUsingHtmlAgilityPack(htmlFromESPN, pageNumber);
            return data.ToList();
        }

        private static Task<string> GetHtml()
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync("https://www.espn.com/golf/rankings");
        }

        private static List<GolfPlayer> ParseHtmlUsingHtmlAgilityPack(string htmlFromESPN, int pageNumber)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlFromESPN);

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
                if(rank >= (pageNumber*10) - 10)
                {
                    data.Add(player);
                }
                if(rank >= pageNumber * 10)
                {
                    return data;
                }
            }
            return data;
        }
    }
}
