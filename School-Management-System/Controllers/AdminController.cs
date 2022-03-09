
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Helpers;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly AppDbContext _context;
        IHttpContextAccessor _httpContextAccessor;

        private readonly IRoomService _roomService;
        private readonly ISchoolService _schoolService;
        private readonly ISubjectService _subjectService;
        public AdminController(IHttpContextAccessor httpContextAccessor,AppDbContext context, IRoomService roomService, ISchoolService schoolService, ISubjectService subjectService)
        {
            _roomService = roomService;
            _schoolService = schoolService;
            _subjectService = subjectService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize(Roles = "admin,school")]
        [HttpGet("home")]
        public async Task<IActionResult> GetHome()
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor,_context);
            if(user.Role=="admin"){
            int Schools = await _context.Users.Where(x => x.Role == "school").CountAsync();
            int Students = await _context.Users.Where(x => x.Role == "student").CountAsync();
            var Teachers = await _context.Users.Where(x => x.Role == "teacher").CountAsync();  
            int Rooms = await _roomService.CountAsync();
            IEnumerable<User> RecentSchools = await _context.Users.Where(x => x.Role == "school").Take(10).ToListAsync();
            var homeDetail = new 
            {
                Schools = Schools,
                Rooms = Rooms,
                Students = Students,
                Teachers = Teachers,
                RecentSchools = RecentSchools
            };
            return Ok(homeDetail);
            }else{
            int Students = await _context.Users.Where(x => x.Role == "student"&&x.SchoolId==user.Id).CountAsync();
            int Subjects = await _context.Subjects.Where(x=>x.SchoolId==user.Id).CountAsync();
            var Teachers = await _context.Users.Where(x => x.Role == "teacher"&&x.SchoolId==user.Id).CountAsync();  
            int Rooms = await _context.Rooms.Where(x=>x.SchoolId==user.Id).CountAsync();
            IEnumerable<User> RecentTeachers = await _context.Users.Where(x => x.Role == "teacher"&&x.SchoolId==user.Id).Take(10).ToListAsync();
            var homeDetail = new 
            {
                Students = Students,
                Rooms = Rooms,
                Subjects = Subjects,
                Teachers = Teachers,
                RecentTeachers = RecentTeachers
            };
            return Ok(homeDetail); 
            }

        }

        [Authorize(Roles = "admin,school")]
        [HttpGet("schools")]
        public async Task<ActionResult> GetSchools()
        {
            var Schools = await _context.Users.Where(x => x.Role == "SCHOOL").ToListAsync();
            return Ok(Schools);
        }


        [Authorize(Roles = "admin,school")]
        [HttpPost("teachers")]
        public async Task<ActionResult> GetTeachers(GetUsersRequest usersRequest)
        {
          User user = await Functions.getCurrentUser(_httpContextAccessor,_context);
            if(user.Role=="admin"){
            var Teachers = await _context.Users.Where(x => x.Role == "teacher"&&x.SchoolId==usersRequest.UserId).ToListAsync();
            return Ok(Teachers);
            }else{
            var Teachers = await _context.Users.Where(x => x.Role == "teacher"&&x.SchoolId==user.Id).ToListAsync();
            return Ok(Teachers);
            }
        }

        [Authorize(Roles = "admin,school")]
        [HttpPost("students")]
        public async Task<ActionResult> GetStudents(GetUsersRequest usersRequest)
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor,_context);
            if(user.Role=="admin"){
            var Students = await _context.Users.Where(x => x.Role == "student"&&x.SchoolId==usersRequest.UserId).ToListAsync();
            return Ok(Students);
            }else{
            var Students = await _context.Users.Where(x => x.Role == "student"&&x.SchoolId==user.Id).ToListAsync();
            return Ok(Students);
            }

        }

         [Authorize(Roles = "admin,school")]
        [HttpGet("rooms")]
        public async Task<ActionResult> GetRooms()
        {
            User user = await Functions.getCurrentUser(_httpContextAccessor,_context);
            if(user.Role=="admin"){
            var Rooms = await _context.Rooms.ToListAsync();
            return Ok(Rooms);
            }else{
            var Rooms = await _context.Rooms.Where(x=>x.SchoolId==user.Id).ToListAsync();
            return Ok(Rooms);
            }

        }
    }
}