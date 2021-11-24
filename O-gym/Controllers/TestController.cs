using Microsoft.AspNetCore.Mvc;

namespace games_store.Controllers
{
    public class TestController: Controller
    {
        [HttpGet("api/test")]
        public IActionResult Get()
        {
            return Ok(new { test = "test" });
        }
    }
}
