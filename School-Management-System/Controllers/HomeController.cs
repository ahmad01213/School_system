using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;

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


        


    }
}