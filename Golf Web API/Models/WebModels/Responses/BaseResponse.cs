using Golf_Web_API.Models.WebModels.Responses.Interfaces;
namespace Golf_Web_API.Models.WebModels.Responses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; set; }
        public BaseResponse()
        {
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}
