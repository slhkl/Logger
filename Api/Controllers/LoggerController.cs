using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(nameof(Info))]
        public IActionResult Info(string text)
        {
            logger.LogInformation(text);
            return Ok();
        }

        [HttpGet(nameof(Warning))]
        public IActionResult Warning(string text)
        {
            logger.LogWarning(text);
            return Ok();
        }
    }
}
