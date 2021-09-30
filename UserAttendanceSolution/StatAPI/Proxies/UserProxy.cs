using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StatAPI.proxies
{
    public class UserProxy: IUserProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;
        public UserProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public async Task UpdateUserAttendance(User user)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json"
                );

            var request = await _httpClient.PutAsync($"{_apiUrls.UserUrl}/Attendances", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
