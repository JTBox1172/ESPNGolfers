using Golf_Web_API.Models.WebModels.Responses.Interfaces;

namespace Golf_Web_API.Models.WebModels.Responses
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
