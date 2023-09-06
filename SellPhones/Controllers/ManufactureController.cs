using Microsoft.AspNetCore.Mvc;
using SellPhones.Service.Interfaces;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class ManufactureController : BaseController
    {
        private readonly IManufactureService _manufactureService;

        public ManufactureController(IManufactureService manufactureService)
        {
            this._manufactureService = manufactureService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _manufactureService.GetAll();
            return Ok(data);
        }
    }
}