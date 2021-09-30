using AttendanceAPI.Settings;
using Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Client
{
    public class DbClient: IDbClient
    {
        private readonly IMongoCollection<Attendance> _attendances;
        public DbClient(IOptions<AttendanceDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _attendances = database.GetCollection<Attendance>(settings.Value.AttendanceCollectionName);

        }
        public IMongoCollection<Attendance> GetAttendancesCollection()
        {
            return _attendances;
        }
    }
}
