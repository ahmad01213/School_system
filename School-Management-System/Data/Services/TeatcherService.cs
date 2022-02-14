using School_Management_System.Data.Base;
using School_Management_System.Models;

namespace School_Management_System.Data.Services
{
    public class TeatcherService : EntityBaseRepository<Teatcher>, ITeatcherService
    {
        public TeatcherService(AppDbContext context) : base(context)
        {
        }
    }
}
