using Golf_Web_API.Models.WebModels.Responses.Interfaces;

namespace Golf_Web_API.Models.WebModels.Responses
{
    public class ItemResponse<T> : SuccessResponse, IItemResponse
    {
        public T Item { get; set; }
        object IItemResponse.Item { get { return this.Item; } }
    }
}