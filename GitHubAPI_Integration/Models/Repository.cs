using System.Text.Json.Serialization;

namespace GitHubAPI_Integration.Models
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
