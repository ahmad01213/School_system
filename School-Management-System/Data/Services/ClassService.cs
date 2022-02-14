using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class ClassService : EntityBaseRepository<Class>, IClassService
    {
        public ClassService(AppDbContext context) : base(context)
        {
        }
    }
}
