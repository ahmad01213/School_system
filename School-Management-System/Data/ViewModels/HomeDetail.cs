using School_Management_System.Models;

namespace School_Management_System.Data.ViewModels
{
    public class HomeDetail
    {
        public int Schools { get; set; }
        public int Teachers { get; set; }
        public int Subjects { get; set; }
        public int Rooms { get; set; }
        public IEnumerable<School> RecentSchools { get; set; }
    }
}
