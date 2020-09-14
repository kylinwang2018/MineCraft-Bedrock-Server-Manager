using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers
{
    public interface IUpdateEngine
    {
        HttpResponse HttpResponse { get; set; }
        Task Run();
        Task Stop();
    }
}