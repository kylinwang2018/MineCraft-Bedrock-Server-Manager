using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineCraft_Bedrock_Server_Manager.Data;

[assembly: HostingStartup(typeof(MineCraft_Bedrock_Server_Manager.Areas.Identity.IdentityHostingStartup))]
namespace MineCraft_Bedrock_Server_Manager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}