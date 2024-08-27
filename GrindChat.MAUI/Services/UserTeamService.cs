using GrindChat.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindChat.MAUI.Services
{
    public class UserTeamService
    {
        private readonly HttpClient _httpClient;

        public UserTeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch a userteam by their ID
        public async Task<UserTeam> GetUserTeamAsync(string userteamId)
        {
            var response = await _httpClient.GetAsync($"api/userteams/{userteamId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserTeam>(json);
            }
            // Handle error cases as needed.
            return null;
        }

        // Authenticate a userteam with email and password
        public async Task<UserTeam> AuthenticateAsync(string email, string password)
        {
            var authRequest = new
            {
                Email = email,
                Password = password
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/userteams/authenticate", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserTeam>(json);
            }
            // Handle error cases as needed.
            return null;
        }
    }
}
