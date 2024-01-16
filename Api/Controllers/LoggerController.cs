using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly Serilog.ILogger logger;

        public LoggerController(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet(nameof(Info))]
        public IActionResult Info(string text)
        {
            logger.Information(text);
            return Ok();
        }

        [HttpPost(nameof(Verbose))]
        public IActionResult Verbose(string text)
        {
            logger.Verbose(text);
            return Ok();
        }

        [HttpPut(nameof(Warning))]
        public IActionResult Warning(string text)
        {
            logger.Warning(text);
            return Ok();
        }

        [HttpDelete(nameof(Error))]
        public IActionResult Error()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return Ok();
        }
    }
}
