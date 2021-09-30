using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StatAPI.Proxies
{
    public interface IAttendanceProxy
    {
        Task DeleteUserAttendances(int userId);
        Task<List<Attendance>> GetUserAttendances(int userId);
    }
}
