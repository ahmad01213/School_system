using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    public class TeatchersController : Controller
    {

        private readonly ITeatcherService _service;
        private readonly ISchoolService _schoolService;
        public TeatchersController(ITeatcherService service, ISchoolService schoolService)
        {
            _service = service;
            _schoolService = schoolService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<Teatcher> TeatcherList = await _service.GetAllAsync();
            List<TeatcherDetail> Teatchers = new List<TeatcherDetail>();

            foreach (var Teatcher in TeatcherList)
            {

                School school = await _schoolService.GetByIdAsync(Teatcher.SchoolId);
                TeatcherDetail TeatcherDetail = new TeatcherDetail()
                {
                    Teatcher = Teatcher,
                    School = school
                };

                Teatchers.Add(TeatcherDetail);

            };
            return View(Teatchers.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            var Schools = await _schoolService.GetAllAsync();
            ViewBag.Schools = Schools;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teatcher row)
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
            ViewBag.Schools = Schools;
            return View(rowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teatcher row)
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
            ViewBag.Schools = Schools;
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
