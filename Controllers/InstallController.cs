using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MineCraft_Bedrock_Server_Manager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    public class InstallController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public InstallController(
            ILogger<HomeController> logger, 
            UserManager<IdentityUser> userManager
            )
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_userManager.Users.Count() > 0)
                return RedirectToAction("Index","Home");
            return View();
        }
    }
}
