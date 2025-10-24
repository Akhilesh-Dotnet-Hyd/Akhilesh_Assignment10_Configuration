using Assignment9_Logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment9_Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MySettings _mySettings;
        public ConfigController(IConfiguration configuration, IOptions<MySettings> mySettings)
        {
            _configuration = configuration;
            _mySettings = mySettings.Value;
        }
        [HttpGet("appsettings")]
        public IActionResult GetAppSettings()
        {
            var manual = new
            {
                Source = "Manual",
                ApplicationName = _configuration["MySettings:ApplicationName"],
                MaxItems = _configuration["MySettings:MaxItems"],
                Version = _configuration["MySettings:Version"]
            };
            var options = new
            {
                Source = "IOptions",
                ApplicationName = _mySettings.ApplicationName,
                MaxItems = _mySettings.MaxItems,
                Version = _mySettings.Version
            };
            return Ok(new { manual, options });
        }
    }
}
