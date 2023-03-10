namespace Golf_Web_API.Models.WebModels.Responses.Interfaces
{
    public interface IItemResponse
    {
        public string TransactionId { get; set; }
        public bool IsSuccessful { get; set; }
        object Item { get; }
    }
}
