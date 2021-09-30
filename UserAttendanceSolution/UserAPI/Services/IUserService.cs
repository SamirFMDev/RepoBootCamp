using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(int id);
        void Create(User user);
        bool Update(User user);
        bool Delete(User user);
        void UpdateUserAttendance(User user);
    }
}
