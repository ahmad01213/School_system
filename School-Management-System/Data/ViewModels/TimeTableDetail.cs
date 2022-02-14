using School_Management_System.Models;

namespace School_Management_System.Data.ViewModels
{
    public class TimeTableDetail
    {
        public Teatcher Teatcher { get; set; }
        public Subject Subject { get; set; }
        public Room Room { get; set; }
        public TimeTable TimeTable { get; set; }
    }
}
