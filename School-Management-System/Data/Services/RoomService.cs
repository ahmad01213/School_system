using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class RoomService : EntityBaseRepository<Room>, IRoomService
    {
        public RoomService(AppDbContext context) : base(context)
        {
        }
    }
}
