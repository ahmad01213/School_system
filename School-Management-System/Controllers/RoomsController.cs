using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    public class RoomsController : Controller
    {

        private readonly IRoomService _service;
        private readonly ISchoolService _schoolService;
        private readonly ISubjectService _subjectService;
        public RoomsController(IRoomService service, ISchoolService schoolService, ISubjectService subjectService)
        {
            _service = service;
            _schoolService = schoolService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<Room> RoomList = await _service.GetAllAsync();
            List<RoomDetail> Rooms = new List<RoomDetail>();

            foreach (var room in RoomList)
            {

                School school = await _schoolService.GetByIdAsync(room.SchoolId);
                Subject subject = await _subjectService.GetByIdAsync(room.SubjectId);
                RoomDetail roomDetail = new RoomDetail()
                {
                    Room = room,
                    Subject = subject,
                    School = school
                };

                Rooms.Add(roomDetail);

            };
            return View(Rooms.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            var Schools = await _schoolService.GetAllAsync();
            var Subjects = await _subjectService.GetAllAsync();
            ViewBag.Schools = Schools;
            ViewBag.Subjects = Subjects;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room row)
        {
            if (!ModelState.IsValid) return View(row);
            await _service.AddAsync(row);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var rowDetails = await _service.GetByIdAsync(id);
            if (rowDetails == null) return View("NotFound");
            var Schools = await _schoolService.GetAllAsync();
            var Subjects = await _subjectService.GetAllAsync();
            ViewBag.Schools = Schools;
            ViewBag.Subjects = Subjects;
            return View(rowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Room row)
        {
            if (!ModelState.IsValid) return View(row);
            await _service.UpdateAsync(id, row);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var rowDetails = await _service.GetByIdAsync(id);
            if (rowDetails == null) return View("NotFound");
            var Schools = await _schoolService.GetAllAsync();
            var Subjects = await _subjectService.GetAllAsync();
            ViewBag.Schools = Schools;
            ViewBag.Subjects = Subjects;
            return View(rowDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var rowDetails = await _service.GetByIdAsync(id);
            if (rowDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
