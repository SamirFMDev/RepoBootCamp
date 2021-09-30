using AttendanceAPI.Client;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Services
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IMongoCollection<Attendance> _attendances;
        public AttendanceService(IDbClient dbClient)
        {
            _attendances = dbClient.GetAttendancesCollection();
        }
        public List<Attendance> GetAttendances()
        {
            return _attendances.Find(attendance => true).ToList();
        }

        public Attendance GetAttendanceById(string id)
        {
            return _attendances.Find(attendance => attendance.Id == id).First();
        }

        public Attendance Create(Attendance attendance)
        {
            _attendances.InsertOne(attendance);
            return attendance;
        }

        public Attendance Update(Attendance updateAttendance)
        {
            //GetAttendanceById(updateAttendance.Id);
            _attendances.ReplaceOne(attendance => attendance.Id == updateAttendance.Id, updateAttendance);
            return updateAttendance;
        }

        public void Delete(string id)
        {
            _attendances.DeleteOne(attendance => attendance.Id == id);
        }

        public void DeleteByUserId(int userId)
        {
            var userIdFilter = Builders<Attendance>.Filter.Eq(attendance => attendance.UserId, userId);
            _attendances.DeleteMany(userIdFilter);
        }

        public int GetTotalUserAttendances(int userId)
        {
            var userIdFilter = Builders<Attendance>.Filter.Eq(attendance => attendance.UserId, userId);
            var result = _attendances.CountDocuments(userIdFilter);
            return (int) result;
        }

        public List<Attendance> GetAttendancesByUserId(int userId)
        {
            var userIdFilter = Builders<Attendance>.Filter.Eq(attendance => attendance.UserId, userId);
            var result = _attendances.Find(userIdFilter).ToList();
            return result;
        }
    }
}
