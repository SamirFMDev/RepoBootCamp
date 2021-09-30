using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserAPI.DataTransferObject.UserObjects;
using UserAPI.Proxies;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IStatProxy _statProxy;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public UsersController(IStatProxy statProxy, IUserService userService, IMapper mapper, IBus bus, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _bus = bus;
            _configuration = configuration;
            _statProxy = statProxy;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            var users = _userService.GetUsers();
            return _mapper.Map<List<UserResponse>>(users);
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<UserAttendanceResponse>> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            List<Attendance> result = await _statProxy.GetUserAttendances(id);
            user.attendances = result;
            return _mapper.Map<UserAttendanceResponse>(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserCreation userReceived)
        {
            User newUser = this._mapper.Map<User>(userReceived);
            _userService.Create(newUser);
            return CreatedAtAction("GetUserById", new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, UserUpdate userUpdate)
        {
            var existingUser = _userService.GetUserById(id);

            if (existingUser is null)
            {
                return NotFound();
            }
            this._mapper.Map(userUpdate, existingUser);

            if (!_userService.Update(existingUser))
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("Attendances")]
        public IActionResult UpdateUserAttendances(UserAttendanceUpdate userUpdate)
        {
            var existingUser = _userService.GetUserById(userUpdate.Id);

            if (existingUser is null)
            {
                return NotFound();
            }

            this._mapper.Map(userUpdate, existingUser);
            _userService.UpdateUserAttendance(existingUser);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            if (!_userService.Delete(existingUser))
            {
                return BadRequest();
            }

            Uri userDeleteUri = new Uri($"{_configuration.GetConnectionString("rabitmq")}/user-stat-queue");
            var userDeleteEndPoint = await _bus.GetSendEndpoint(userDeleteUri);
            await userDeleteEndPoint.Send(existingUser);

            return Ok();
        }
    }
}
