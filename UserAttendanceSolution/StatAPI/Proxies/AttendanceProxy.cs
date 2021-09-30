using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StatAPI.Proxies
{
    public class AttendanceProxy : IAttendanceProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;
        public AttendanceProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public async Task DeleteUserAttendances(int userId)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.AttendanceUrl}/User/{userId}");
            request.EnsureSuccessStatusCode();
        }

        public async Task<List<Attendance>> GetUserAttendances(int userId)
        {
            List<Attendance> attendanceList = null;
            var response = await _httpClient.GetAsync($"{_apiUrls.AttendanceUrl}/UserAttendance/{userId}");
            var responseString = await response.Content.ReadAsStringAsync();
            attendanceList = JsonSerializer.Deserialize<List<Attendance>>(responseString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //request.EnsureSuccessStatusCode();
            return attendanceList;
        }
    }
}
