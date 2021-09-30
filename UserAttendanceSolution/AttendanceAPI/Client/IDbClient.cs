using Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Client
{
    public interface IDbClient
    {
        IMongoCollection<Attendance> GetAttendancesCollection();
    }
}
