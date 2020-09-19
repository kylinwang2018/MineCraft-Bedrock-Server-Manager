using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace MineCraft_Bedrock_Server_Manager.Services
{
    public class ServerOprationService : IHostedService, IDisposable
    {
        private readonly ILogger<ServerOprationService> _logger;
        private Process _mcProcess;
        private StreamWriter _mcInputStream;

        public ServerOprationService(ILogger<ServerOprationService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Server Opeartion Service running.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Server Opeartion Service stoping.");

            return Task.CompletedTask;
        }

        public bool StartServer()
        {
            if (_mcProcess != null)
            {
                _logger.LogError("Cannot start another server while one server is running.");
                return false;
            }
        }

        public void Dispose()
        {
            //_timer?.Dispose();
        }
    }
}