using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserAPI.Proxies
{
    public interface IStatProxy
    {
        Task<List<Attendance>> GetUserAttendances(int userId);
    }
}
