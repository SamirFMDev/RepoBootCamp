using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceAPI.Services
{
    public interface IAttendanceService
    {
        List<Attendance> GetAttendances();
        List<Attendance> GetAttendancesByUserId(int userId);
        Attendance GetAttendanceById(string id);
        Attendance Create(Attendance attendance);
        Attendance Update(Attendance attendance);
        void Delete(string id);
        void DeleteByUserId(int userId);
        int GetTotalUserAttendances(int userId);
    }
}
