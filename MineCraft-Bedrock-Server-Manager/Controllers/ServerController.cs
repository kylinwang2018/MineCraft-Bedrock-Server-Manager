using System;
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
        private readonly ILogger<ServerController> _logger;
        private readonly IConfiguration _configuration;

        public ServerController(
            ILogger<ServerController> logger,
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
            var updateEngine = new UpdateEngine(_configuration,_logger);
            updateEngine.HttpResponse = Response;
            await updateEngine.Run();
        }
    }
}
