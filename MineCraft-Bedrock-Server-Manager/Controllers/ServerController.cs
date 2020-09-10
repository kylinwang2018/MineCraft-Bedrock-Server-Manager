﻿using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MineCraft_Bedrock_Server_Manager.ServerControlHelpers;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    [Authorize]
    public class ServerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public ServerController(
            ILogger<HomeController> logger,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _configuration = configuration;
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

        [HttpGet]
        public async Task<IActionResult> GetLatestVersion()
        {
            var result = await HttpAnalyser.GetLatestVersionNum(_configuration["ServerApplication:ServerDownloadPageUrl"]);
            if (result == null)
                return Json(new { status = false });

            return Json(new { status = true, data = result });
        }

        [HttpGet]
        public async Task DownloadNewVersion()
        {
            // check version
            // compaire with current version
            // download
            // unzip
            // stop
            // copy files
            // restart server
            // delete files

            
        }
    }
}
