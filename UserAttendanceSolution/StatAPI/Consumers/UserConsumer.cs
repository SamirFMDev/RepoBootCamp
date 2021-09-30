using Domain;
using MassTransit;
using Microsoft.Extensions.Configuration;
using StatAPI.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatAPI.Consumers
{
    public class UserConsumer : IConsumer<User>
    {
        private IAttendanceProxy _attendanceProxy;
        public UserConsumer(IAttendanceProxy attendanceProxy)
        {
            _attendanceProxy = attendanceProxy;
        }
        public async Task Consume(ConsumeContext<User> context)
        {
            await Console.Out.WriteLineAsync($"userId: { context.Message.Id }; totalAttendance: { context.Message.TotalAttendance }");

            await _attendanceProxy.DeleteUserAttendances(context.Message.Id);
        }
    }
}
