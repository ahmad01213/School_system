
using School_Management_System.Models;

namespace School_Management_System.Data.ViewModels
{
    public class AddTimeTable
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public TimeTable TimeTable { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Teatcher> Teatchers { get; set; }
        public List<string> Days { get; set; }
        public List<string> Times { get; set; }

        public List<int> Permittimes { get; set; }

        public AddTimeTable() {

        Permittimes = new List<int>();
         Days = new List<string>()
          {
            "Saturday",
            "Sunday",
            "Monday",
            "Thursday",
            "Tuesday",
            "Wednesday",
            "Friday",
           };

            Days = new List<string>()
          {
            "6:00",
            "6:30",
            "7:00",
            "7:30",
            "8:00",
            "8:30",
            "9:00",
            "9:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
           };


            for (int i = 0; i < 3; i++)
            {
                Permittimes.Add((i + 1) * 5);
            }
        }

    }
}
