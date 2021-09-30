using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.DataTransferObject.UserObjects
{
    public class UserAttendanceResponse
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public int TotalAttendance { get; set; }
        public List<Attendance> attendances { get; set; }
    }
}
