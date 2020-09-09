using System;
using Microsoft.AspNetCore.Mvc;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    public class ServerController : Controller
    {
        public ServerController()
        {
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
