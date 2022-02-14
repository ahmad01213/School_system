using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;
namespace School_Management_System.Controllers
{
    public class TimeTablesController : Controller
    {
        private readonly ITimeTableService _service;
        private readonly ITeatcherService _teatcherService;
        private readonly ISubjectService _subjectService;
        private readonly IRoomService _roomService;
        public TimeTablesController(ITimeTableService service,ITeatcherService teatcherService,IRoomService roomService,ISubjectService subjectService)
        {
            _service = service;
            _teatcherService = teatcherService;
            _subjectService = subjectService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<TimeTable> TimeTableList = await _service.GetAllAsync();
            List<TimeTableDetail> TimeTables = new List<TimeTableDetail>();

            foreach (var timeTable in TimeTableList)
            {
                Teatcher Teatcher = await _teatcherService.GetByIdAsync(timeTable.TeatcherId);
                Subject Subject = await _subjectService.GetByIdAsync(timeTable.SubjectId);
                Room Room = await _roomService.GetByIdAsync(timeTable.RoomId);
                TimeTableDetail TimeTableDetail = new TimeTableDetail()
                {
                    Teatcher = Teatcher,
                     Subject = Subject,
                     TimeTable = timeTable,
                     Room = Room
                };

                TimeTables.Add(TimeTableDetail);

            };
            return View(TimeTables.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            var Teatchers = await _teatcherService.GetAllAsync();
            var Rooms     = await _roomService.GetAllAsync();
            var Subjects =  await _subjectService.GetAllAsync();
            AddTimeTable addTimeTable = new AddTimeTable()
            {
                Subjects = Subjects,
                Rooms = Rooms,
                Teatchers = Teatchers
            };
            ViewBag.Data = addTimeTable;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TimeTable row)
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
            var Teatchers = await _teatcherService.GetAllAsync();
            var Rooms = await _roomService.GetAllAsync();
            var Subjects = await _subjectService.GetAllAsync();
            AddTimeTable addTimeTable = new AddTimeTable()
            {
                Subjects = Subjects,
                Rooms = Rooms,
                Teatchers = Teatchers
            };
            ViewBag.Data = addTimeTable;

            return View(rowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TimeTable row)
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
            var Teatchers = await _teatcherService.GetAllAsync();
            var Rooms = await _roomService.GetAllAsync();
            var Subjects = await _subjectService.GetAllAsync();
            AddTimeTable addTimeTable = new AddTimeTable()
            {
                Subjects = Subjects,
                Rooms = Rooms,
                Teatchers = Teatchers
            };
            ViewBag.Data = addTimeTable;
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
