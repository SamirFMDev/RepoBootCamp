using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatAPI.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private IAttendanceProxy _attendanceProxy;
        public StatsController(IAttendanceProxy attendanceProxy)
        {
            _attendanceProxy = attendanceProxy;
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances(int userId)
        {
            return Ok(await _attendanceProxy.GetUserAttendances(userId));
        }
    }
}
