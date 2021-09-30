using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.DataTransferObject.AttendanceObjects
{
    public class AttendanceCreation
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
