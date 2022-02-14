using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _service;
        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var subjects = await _service.GetAllAsync();
            return View(subjects.ToList().ToPagedList(pageNumber,pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (!ModelState.IsValid) return View(subject);
            await _service.AddAsync(subject);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var rowDetails = await _service.GetByIdAsync(id);
            if (rowDetails == null) return View("NotFound");
            return View(rowDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Subject row)
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
