using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    [Authorize]
    public class ServerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ServerController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Status()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Configuration()
        {
            return View();
        }

        public IActionResult Permissions()
        {
            return View();
        }

        public IActionResult Backup()
        {
            return View();
        }
    }
}
