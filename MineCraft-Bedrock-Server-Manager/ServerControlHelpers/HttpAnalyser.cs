using System.Threading.Tasks;
using System.Net.Http;

namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers
{
    public static class HttpAnalyser
    {
        public async static Task<string> GetDownloadUrl(string htmlPageUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            if (string.IsNullOrWhiteSpace(htmlPageUrl))
                return null;

            try
            {
                response = await client.GetAsync(htmlPageUrl);
            }
            catch
            {
                return null;
            }

            var pageContents = await response.Content.ReadAsStringAsync();
            var urlStartIndex = pageContents.IndexOf("https://minecraft.azureedge.net/bin-linux/");
            if (urlStartIndex == -1)
                return null;
            var urlEndIndex = pageContents.IndexOf(".zip", urlStartIndex);
            if (urlEndIndex == -1)
                return null;
            return pageContents.Substring(urlStartIndex, urlEndIndex - urlStartIndex + 4);
        }

        public async static Task<string> GetLatestVersionNum(string htmlPageUrl)
        {
            var downloadUrl = await GetDownloadUrl(htmlPageUrl);
            if (downloadUrl != null)
            {
                var headerString = "bedrock-server-";
                var endingString = ".zip";
                var startIndex = downloadUrl.IndexOf(headerString) + headerString.Length;
                var endIndex = downloadUrl.IndexOf(endingString);
                if (startIndex == -1 || endIndex == -1)
                    return null;
                return downloadUrl.Substring(startIndex, endIndex - startIndex);
            }
            else
                return null;
        }
    }
}