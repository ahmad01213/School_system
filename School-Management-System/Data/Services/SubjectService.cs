using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class SubjectService : EntityBaseRepository<Subject>, ISubjectService
    {
        public SubjectService(AppDbContext context) : base(context)
        {
        }
    }
}
