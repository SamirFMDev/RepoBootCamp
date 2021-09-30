using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatAPI.proxies
{
    public interface IUserProxy
    {
        Task UpdateUserAttendance(User user);
    }
}
