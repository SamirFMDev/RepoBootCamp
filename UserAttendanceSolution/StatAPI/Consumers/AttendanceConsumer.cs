using Domain;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StatAPI.proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserAPI.Services;

namespace StatAPI.Consumers
{
    public class AttendanceConsumer : IConsumer<User>
    {
        private IUserProxy _userProxy;

        public AttendanceConsumer(IUserProxy userProxy)
        {
            _userProxy = userProxy;
        }
        public async Task Consume(ConsumeContext<User> context)
        {
            await Console.Out.WriteLineAsync($"userId: { context.Message.Id }; totalAttendance: { context.Message.TotalAttendance }");

            await _userProxy.UpdateUserAttendance(context.Message);
        }
    }
}
