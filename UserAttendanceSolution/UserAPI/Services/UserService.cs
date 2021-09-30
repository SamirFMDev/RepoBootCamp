using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;
        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Delete(User user)
        {
            var deleted = _context.Users.Remove(user) != null;
            if (deleted)
            {
                _context.SaveChanges();
            }
            return deleted;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool Update(User user)
        {
            //_context.Entry(user).State = EntityState.Modified;
            var updated = _context.Users.Update(user) != null;
            if (updated)
            {
                _context.SaveChanges();
            }
            return updated;
        }

        public void UpdateUserAttendance(User user)
        {
            var existingUser = GetUserById(user.Id);
            existingUser.TotalAttendance = user.TotalAttendance;
            _context.Users.Update(existingUser);
            _context.SaveChanges();
        }
    }
}
