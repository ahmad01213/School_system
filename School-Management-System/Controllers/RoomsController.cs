using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Data.Services;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;
using X.PagedList;

namespace School_Management_System.Controllers
{
    
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomsController(IRoomService service)
        {
            _service = service;
        }
         
        [Authorize(Roles ="school")]
        [HttpPost("room/add")]
        public async Task<IActionResult> Create(Room roomToadd)
        {
            await _service.AddAsync(roomToadd);
            return Ok(roomToadd);
        }

        [Authorize(Roles ="school")]
        [HttpPost("room/delete")]
        public async Task<IActionResult> Delete(RoomToDelete RoomToDelete)
        {

            await _service.DeleteAsync(RoomToDelete.RoomId);
            return Ok(true);
        }

  

    }
}
