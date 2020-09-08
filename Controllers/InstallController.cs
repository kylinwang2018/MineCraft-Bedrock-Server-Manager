using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MineCraft_Bedrock_Server_Manager.Models;
using Microsoft.AspNetCore.Authorization;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    public class InstallController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public InstallController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
