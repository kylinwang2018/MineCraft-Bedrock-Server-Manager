using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers
{
    public class UpdateEngine : IUpdateEngine
    {
        public HttpResponse HttpResponse {get;set;}
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        private static bool updateLock;

        public UpdateEngine(
            IConfiguration configuration,
            ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Run()
        {
            HttpResponse.Headers.Add("Content-Type", "text/event-stream");
            // Check if the system is already under updating
            if (updateLock)
            {
                await SendEvent("Error: The server is being updated at the background.");
                _logger.LogWarning("Someone is trying to update server application while the server is being updated at the background.");
                return;
            }

            updateLock = true;

            // get downlaod url
            var downlaodUrl = await HttpAnalyser.GetDownloadUrl(
                _configuration["ServerApplication:ServerDownloadPageUrl"]);
            if (downlaodUrl == null)
                return;

            // extract version
            var newVersion = HttpAnalyser.GetLatestVersionNum(downlaodUrl);

            // compaire with current version

            // pre-install
            var downloadDir = "Downloads";
            var newVersionZipFileName = "new.zip";
            var downloadPath = Path.Combine(downloadDir, newVersionZipFileName);
            var serverDir = "MCServer";
            var newServerPath = Path.Combine(serverDir, newVersion);


            Directory.CreateDirectory(downloadDir);
            Directory.CreateDirectory(serverDir);
            //if ()


            // download
            var downloader = new Downloader(downlaodUrl, downloadPath);
            await SendEvent("Download Started.");
            await downloader.BeginDownload(async (object sender, AsyncCompletedEventArgs e) =>
            {
                if (e.Cancelled)
                    await SendEvent("Error: Download Failed.");
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

        public async Task Stop(){

        }

        private async Task SendEvent(string message)
        {
            string dataItem = $"data: {message}\n\n";
            byte[] dataItemBytes = ASCIIEncoding.ASCII.GetBytes(dataItem);
            await HttpResponse.Body.WriteAsync(dataItemBytes, 0, dataItemBytes.Length);
            await HttpResponse.Body.FlushAsync();
        }

    }

}