using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class TimeTableService : EntityBaseRepository<TimeTable>, ITimeTableService
    {
        public TimeTableService(AppDbContext context) : base(context)
        {
        }
    }
}
