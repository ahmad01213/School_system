using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class SchoolService:EntityBaseRepository<School>, ISchoolService
    {
        public SchoolService(AppDbContext context) : base(context)
        {
        }

    }
}
