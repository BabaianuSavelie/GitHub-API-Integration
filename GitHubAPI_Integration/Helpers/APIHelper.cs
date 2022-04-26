using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubAPI_Integration.Helpers
{
    public class APIHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            ApiClient.DefaultRequestHeaders.Add("User-Agent", "Get Repositories from username");
        }

    }
}
