using GrindChat.Library.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GrindChat.MAUI.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<User> GetUserAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/users/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(json);
                }
                // Log or handle error cases as needed.
            }
            catch (Exception ex)
            {
                // Log or handle exceptions. Perhaps rethrow, or notify the user.
            }
            return null;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            try
            {
                var authRequest = new
                {
                    Email = email,
                    Password = password
                };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/users/authenticate", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(json);
                }
                // Log or handle error cases as needed.
            }
            catch (Exception ex)
            {
                // Log or handle exceptions. Perhaps rethrow, or notify the user.
            }
            return null;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/users/register", jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    // Log or handle error cases.
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new InvalidOperationException($"Registration failed: {errorContent}");
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions. Perhaps rethrow, or notify the user.
                throw;  // Rethrowing for now, but you can handle it as needed.
            }
        }
    }
}
