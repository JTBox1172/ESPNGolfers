using Microsoft.AspNetCore.Mvc;
using Golf_Web_API.Services;
using Golf_Web_API.Services.Interfaces;
using Golf_Web_API.Models;
using Golf_Web_API.Models.WebModels.Responses;

namespace Golf_Web_API.Controllers
{
    [Route("api/golf")]
    [ApiController]
    public class GolfController : ControllerBase
    {
        private IGetGolfers _service = null;

        public GolfController(IGetGolfers service) { 
            _service = service;
        }

        [HttpGet]
        public ActionResult<TaskItemsResponse<GolfPlayer>> getGolfers()
        {
            int iCode = 200;
            BaseResponse response = null;
            try
            {
                Task<List<GolfPlayer>> golfers = _service.scrapeForGolfers();
                response = new TaskItemsResponse<GolfPlayer>(golfers);
                
            }
            catch (Exception ex)
            {
                response = new ErrorResponse(ex.Message);
                iCode = 500;
            }
            return StatusCode(iCode, response);
        }

    }
}
