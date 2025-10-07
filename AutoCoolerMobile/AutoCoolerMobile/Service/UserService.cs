using AutoCoolerMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoolerMobile.Service
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(AppConfig.ApiBaseUrl) };
        }

        public async Task<UserLoginDto> Login(LoginRequest loginRequest)
        {
            var jsonContent = JsonConvert.SerializeObject(loginRequest);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/User/Login", stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserLoginDto>(responseContent);
            }
            else
            {
                throw new Exception("Login failed");
            }
        }

    }
}
