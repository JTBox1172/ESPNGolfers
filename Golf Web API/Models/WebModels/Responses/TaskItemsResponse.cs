
namespace Golf_Web_API.Models.WebModels.Responses
{
    public class TaskItemsResponse<T> : SuccessResponse
    {
        public Task<List<T>> Items { get; set; }

        public TaskItemsResponse(Task<List<T>> Items) 
        {
            this.Items = Items;
        }
    }
}
