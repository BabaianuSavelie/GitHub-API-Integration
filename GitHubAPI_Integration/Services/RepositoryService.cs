using GitHubAPI_Integration.Helpers;
using GitHubAPI_Integration.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubAPI_Integration.Services
{
    public static class RepositoryService
    {
        public static async Task<IEnumerable<Repository>> GetAllRepositories(string username)
        {
            string url = $"https://api.github.com/users/{username}/repos";
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(
                        await response.Content.ReadAsStreamAsync());
                    return repositories;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
