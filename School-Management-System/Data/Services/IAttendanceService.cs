using School_Management_System.Data.Base;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
 

    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDetail>> SearchAllAsync(int SchoolId, DateTime Date);
    }
}
