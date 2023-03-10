namespace Golf_Web_API.Models.WebModels.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public List<string> Errors { get; set; }

        public ErrorResponse(string error)
        {
            Errors = new List<string>();
            Errors.Add(error);
            this.IsSuccessful = false;
        }
        public ErrorResponse(IEnumerable<string> errors) 
        {
            Errors = new List<string>();
            Errors.AddRange(errors);
            this.IsSuccessful = false;
        }
    }
}
