using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MineCraft_Bedrock_Server_Manager.ServerControlHelpers;
using MineCraft_Bedrock_Server_Manager.Services;


namespace MineCraft_Bedrock_Server_Manager.Controllers
{

    [Authorize]
    public class ServerController : Controller
    {
        private readonly ILogger<ServerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ServerOprationService _serverOpreationService;

        public ServerController(
            ILogger<ServerController> logger,
            IConfiguration configuration,
            ServerOprationService serverOprationService
            )
        {
            _logger = logger;
            _configuration = configuration;
            _serverOpreationService = serverOprationService;
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
            var updateEngine = new UpdateEngine(_configuration,_logger,_serverOpreationService);
            updateEngine.HttpResponse = Response;
            await updateEngine.Run();
        }
    }
}
