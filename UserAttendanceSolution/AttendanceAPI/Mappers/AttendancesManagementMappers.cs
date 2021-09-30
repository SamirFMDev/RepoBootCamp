using AttendanceAPI.DataTransferObject.AttendanceObjects;
using AutoMapper;
using Domain;

namespace AttendanceAPI.Mappers
{
    public class AttendancesManagementMappers : Profile
    {
        public AttendancesManagementMappers()
        {
            this.SetAttendanceMappers();
        }

        public void SetAttendanceMappers()
        {
            this.CreateMap<AttendanceCreation, Attendance>();
            this.CreateMap<AttendanceUpdate, Attendance>();
            this.CreateMap<Attendance, AttendanceResponse>();
        }
    }
}
