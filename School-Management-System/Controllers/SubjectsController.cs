using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{

    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;
        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }




         
         [Authorize(Roles ="admin")]
        [HttpPost("subject/add")]
        public async Task<IActionResult> Create(Subject subject)
        {
            await _service.AddAsync(subject);
            return Ok(subject);
        }

        [Authorize(Roles ="admin")]
        [HttpPost("subject/delete")]
        public async Task<IActionResult> Delete(SubjectToDelete subjectToDelete)
        {

            await _service.DeleteAsync(subjectToDelete.SubjectId);
            return Ok(true);
        }

        [Authorize(Roles ="admin,school")]
        [HttpGet("subjects")]
        public async Task<IActionResult> Get()
        {
           var Subjects =  await _service.GetAllAsync();
            return Ok(Subjects);
        }

    }
}
