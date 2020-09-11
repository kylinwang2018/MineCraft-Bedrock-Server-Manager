using System;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MineCraft_Bedrock_Server_Manager.ServerControlHelpers;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{

    [Authorize]
    public class ServerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private static bool updateLock = false;

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
            // TODO: return current version with view model
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
            var result = HttpAnalyser.GetLatestVersionNum(
                await HttpAnalyser.GetDownloadUrl(
                    _configuration["ServerApplication:ServerDownloadPageUrl"]
                    ));
            if (result == null)
                return Json(new { status = false });

            return Json(new { status = true, data = result });
        }

        [HttpGet]
        public async Task DownloadNewVersion()
        {

            Response.Headers.Add("Content-Type", "text/event-stream");

            // Check if the system is already under updating
            if (updateLock)
            {
                await SendEvent("Server is being updated at background. ");
                return;
            }

            // pre-install
            Directory.CreateDirectory("Downloads");
                // TODO: clean this folder

            // get downlaod url
            var downlaodUrl = await HttpAnalyser.GetDownloadUrl(_configuration["ServerApplication:ServerDownloadPageUrl"]);
            if (downlaodUrl == null)
                return;

            // extract version
            var newVersion = HttpAnalyser.GetLatestVersionNum(downlaodUrl);


            // compaire with current version
            // download
            var downloader = new Downloader(downlaodUrl, "Downloads/new.zip");
            await SendEvent("Download Started.");
            await downloader.BeginDownload(async (object sender, AsyncCompletedEventArgs e) => {
                if (e.Cancelled)
                    await SendEvent("Download Failed.");
                else
                    await SendEvent("Download Completed.");
            });

            // unzip
            // stop
            // copy files
            // restart server
            // delete files

            updateLock = false;
        }

        private async Task SendEvent(string message)
        {
            string dataItem = $"data: {message}\n\n";
            byte[] dataItemBytes = ASCIIEncoding.ASCII.GetBytes(dataItem);
            await Response.Body.WriteAsync(dataItemBytes, 0, dataItemBytes.Length);
            await Response.Body.FlushAsync();
        }
    }
}
