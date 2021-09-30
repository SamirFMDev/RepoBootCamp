using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserAPI.Proxies
{
    public class StatProxy : IStatProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public StatProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }
        public async Task<List<Attendance>> GetUserAttendances(int userId)
        {
            List<Attendance> attendanceList = null;
            var response = await _httpClient.GetAsync($"{_apiUrls.StatUrl}/User/{userId}");
            var responseString = await response.Content.ReadAsStringAsync();
            attendanceList = JsonSerializer.Deserialize<List<Attendance>>(responseString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //request.EnsureSuccessStatusCode();
            return attendanceList;
        }
    }
}
