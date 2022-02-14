using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    public class ClassesController : Controller
    {

        private readonly IClassService _service;
        private readonly ISchoolService _schoolService;
        public ClassesController(IClassService service, ISchoolService schoolService)
        {
            _service = service;
            _schoolService = schoolService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<Class> ClassList = await _service.GetAllAsync();
            List<ClassDetail> Classs = new List<ClassDetail>();

            foreach (var Class in ClassList)
            {

                School school = await _schoolService.GetByIdAsync(Class.SchoolId);
                ClassDetail ClassDetail = new ClassDetail()
                {
                    Class = Class,
                    School = school
                };

                Classs.Add(ClassDetail);
            };
            return View(Classs.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            var Schools = await _schoolService.GetAllAsync();
            ViewBag.Schools = Schools;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Class row)
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
        public async Task<IActionResult> Edit(int id, Class row)
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
