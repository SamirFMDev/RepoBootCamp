using AutoMapper;
using Domain;
using UserAPI.DataTransferObject.UserObjects;

namespace UserAPI.Mappers
{
    public class UserManagementMappers : Profile
    {
        public UserManagementMappers()
        {
            this.SetUserMappers();
        }

        public void SetUserMappers()
        {
            this.CreateMap<UserCreation, User>();
            this.CreateMap<UserUpdate, User>();
            this.CreateMap<UserAttendanceUpdate, User>();
            this.CreateMap<User, UserResponse>();
            this.CreateMap<User, UserAttendanceResponse>();
        }
    }
}
