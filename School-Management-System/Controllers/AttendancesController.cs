using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;


namespace School_Management_System.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ISchoolService _schoolService;
        private readonly IAttendanceService _service;
        public AttendancesController(IAttendanceService service, ISchoolService schoolService)
        {
            _schoolService = schoolService;
            _service = service;
        }

        public async Task<IActionResult> Index(int SchoolId, DateTime Date)
        {

            if (SchoolId == null)
            {
                return View();
            }
            var Schools = await _schoolService.GetAllAsync();
            ViewBag.Schools = Schools;
            IEnumerable<AttendanceDetail> Attendances = await _service.SearchAllAsync( SchoolId,  Date);
            return View(Attendances);
        }

    }
}
