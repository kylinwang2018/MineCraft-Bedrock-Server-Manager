using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MineCraft_Bedrock_Server_Manager.Services
{
    public class ServerOprationService : IHostedService, IDisposable
    {
        private readonly ILogger<ServerOprationService> _logger;
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

        public void Dispose()
        {
            //_timer?.Dispose();
        }
    }
}