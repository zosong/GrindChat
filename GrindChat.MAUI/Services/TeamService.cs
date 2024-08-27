using GrindChat.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace GrindChat.MAUI.Services
    {
        public class TeamService
        {
            private readonly HttpClient _httpClient;

            public TeamService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            // Fetch a team by their ID
            public async Task<Team> GetTeamAsync(string teamId)
            {
                var response = await _httpClient.GetAsync($"api/teams/{teamId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Team>(json);
                }
                // Handle error cases as needed.
                return null;
            }

            // Authenticate a team with email and password
            public async Task<Team> AuthenticateAsync(string email, string password)
            {
                var authRequest = new
                {
                    Email = email,
                    Password = password
                };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/teams/authenticate", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Team>(json);
                }
                // Handle error cases as needed.
                return null;
            }
        }
    }


