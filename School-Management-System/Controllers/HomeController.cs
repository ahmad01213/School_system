using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using System.Diagnostics;

namespace School_Management_System.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRoomService _roomService;
        private readonly ISchoolService _schoolService;
        private readonly ISubjectService _subjectService;
        public HomeController(IRoomService roomService, ISchoolService schoolService, ISubjectService subjectService)
        {
            _roomService = roomService;
            _schoolService = schoolService;
            _subjectService = subjectService;
        }
         public async Task<IActionResult> Index()
        {
            int Schools = await _schoolService.CountAsync();
            int Subjects = await _subjectService.CountAsync();
            int Rooms = await _roomService.CountAsync();
            IEnumerable<School> RecentSchools = await _schoolService.GetRangeAsync(10);
            HomeDetail homeDetail = new HomeDetail()
            {
            Schools = Schools,
            Rooms = Rooms,
            Subjects = Subjects,
            Teachers = 4,
            RecentSchools = RecentSchools
            };
            return View(homeDetail);
        }

    }
}