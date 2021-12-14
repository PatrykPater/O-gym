﻿using Microsoft.AspNetCore.Mvc;

namespace O_gym.Controllers
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