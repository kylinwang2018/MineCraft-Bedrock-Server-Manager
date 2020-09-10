using System.Threading.Tasks;
using System.Net.Http;

namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers
{
    public static class HttpAnalyser
    {
        public async static Task<string> GetDownloadUrl(string htmlPageUrl){
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(htmlPageUrl);
            var pageContents = await response.Content.ReadAsStringAsync();
            var urlStartIndex = pageContents.IndexOf("https://minecraft.azureedge.net/bin-linux/");
            return pageContents.Substring(urlStartIndex, pageContents.IndexOf(".zip",urlStartIndex) - urlStartIndex);
        }
    }
}