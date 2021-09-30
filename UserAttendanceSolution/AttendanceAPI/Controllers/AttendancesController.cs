using AttendanceAPI.DataTransferObject.AttendanceObjects;
using AttendanceAPI.Services;
using AutoMapper;
using Domain;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceServices;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        public AttendancesController(IAttendanceService attendanceServices, IMapper mapper, IPublishEndpoint publishEndpoint, IBus bus, IConfiguration configuration)
        {
            _attendanceServices = attendanceServices;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _bus = bus;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceResponse>> GetAttendances()
        {
            var attendances = _attendanceServices.GetAttendances();
            return _mapper.Map<List<AttendanceResponse>>(attendances);
        }

        [HttpGet("UserAttendance/{userId:int}")]
        public ActionResult<IEnumerable<AttendanceResponse>> GetAttendancesByUserId(int userId)
        {
            var attendances = _attendanceServices.GetAttendancesByUserId(userId);
            if (attendances is null)
            {
                return NotFound();
            }
            return _mapper.Map<List<AttendanceResponse>>(attendances);
        }

        [HttpGet("{id}", Name = "GetAttendanceById")]
        public ActionResult<AttendanceResponse> GetAttendanceById(string id)
        {
            var attendance = _attendanceServices.GetAttendanceById(id);
            if(attendance is null)
            {
                return NotFound();
            }
            return _mapper.Map<AttendanceResponse>(attendance);
        }

        [HttpPost]
        public async Task<ActionResult<Attendance>> CreateAttendance(AttendanceCreation attendanceReceived)
        {
            Attendance newAttendance = this._mapper.Map<Attendance>(attendanceReceived);
            var insertedAttendance = _attendanceServices.Create(newAttendance);
            if(insertedAttendance is null)
            {
                return BadRequest();
            }
            int totalUserAttendance = _attendanceServices.GetTotalUserAttendances(newAttendance.UserId);
            //await _publishEndpoint.Publish(new User { Id = newAttendance.UserId, TotalAttendance = totalUserAttendance });

            Uri attendanceUri = new Uri($"{_configuration.GetConnectionString("rabitmq")}/attendance-stat-queue");
            var attendanceEndPoint = await _bus.GetSendEndpoint(attendanceUri);
            await attendanceEndPoint.Send(
                new User 
                { 
                    Id = newAttendance.UserId, 
                    TotalAttendance = totalUserAttendance 
                });

            return CreatedAtRoute("GetAttendanceById", new { id = newAttendance.Id }, newAttendance);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttendance(string id, AttendanceUpdate attendanceUpdate)
        {
            Attendance existingAttendance = _attendanceServices.GetAttendanceById(id);

            if (existingAttendance is null)
            {
                return NotFound();
            }
            this._mapper.Map(attendanceUpdate, existingAttendance);
            return Ok(_attendanceServices.Update(existingAttendance));
        }

        [HttpDelete("{id}/User/{userId}")]
        public async Task<IActionResult> DeleteAttendance(string id, int userId)
        {
            Attendance existingAttendance = _attendanceServices.GetAttendanceById(id);
            if (existingAttendance is null)
            {
                return NotFound();
            }
            if (existingAttendance.UserId != userId)
            {
                return BadRequest();
            }
            _attendanceServices.Delete(id);

            int totalUserAttendance = _attendanceServices.GetTotalUserAttendances(existingAttendance.UserId);
            //await _publishEndpoint.Publish(new User { Id = existingAttendance.UserId, TotalAttendance = totalUserAttendance });

            Uri attendanceUri = new Uri($"{_configuration.GetConnectionString("rabitmq")}/attendance-stat-queue");
            var attendanceEndPoint = await _bus.GetSendEndpoint(attendanceUri);
            await attendanceEndPoint.Send(
                new User
                {
                    Id = existingAttendance.UserId,
                    TotalAttendance = totalUserAttendance
                });
            return NoContent();
        }

        [HttpDelete("User/{userId}")]
        public IActionResult DeleteByUserId(int userId)
        {
            _attendanceServices.DeleteByUserId(userId);
            return NoContent();
        }
    }
}
