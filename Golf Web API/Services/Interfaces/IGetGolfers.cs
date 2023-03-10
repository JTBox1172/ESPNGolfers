using Golf_Web_API.Models;

namespace Golf_Web_API.Services.Interfaces
{
    public interface IGetGolfers
    {
        public Task<List<GolfPlayer>> scrapeForGolfers();


    }
}