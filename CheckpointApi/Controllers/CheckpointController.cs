using Microsoft.AspNetCore.Mvc;

namespace CheckpointApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckpointController : ControllerBase
    {
        private readonly ILogger<CheckpointController> _logger;

        public CheckpointController(ILogger<CheckpointController> logger)
        {
            _logger = logger;
        }

        static bool isInUse = false;
        static Random random = new Random();

        [HttpPost("Open")]
        public async Task<ActionResult> OpenCheckpoint()
        {
            if (isInUse)
                return BadRequest();
            isInUse = true;
            await Task.Delay(random.Next(2000, 6000));
            isInUse = false;
            return Ok();
        }
    }
}