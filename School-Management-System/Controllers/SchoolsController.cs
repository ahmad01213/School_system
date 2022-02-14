using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    public class SchoolsController : Controller
    {

        private readonly ISchoolService _service;

        public SchoolsController(ISchoolService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var schools = await _service.GetAllAsync( );
            return View(schools.ToList().ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(School school)
        {
            if (!ModelState.IsValid) return View(school);
            await _service.AddAsync(school);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var schoolDetails = await _service.GetByIdAsync(id);
            if (schoolDetails == null) return View("NotFound");
            return View(schoolDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, School school)
        {
            if (!ModelState.IsValid) return View(school);
            await _service.UpdateAsync(id, school);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
 
        public async Task<IActionResult> Delete(int id)
        {
            var schoolDetails = await _service.GetByIdAsync(id);
            if (schoolDetails == null) return View("NotFound");
            return View(schoolDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
