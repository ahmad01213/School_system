using School_Management_System.Data.Base;

namespace School_Management_System.Models
{
    public class TimeTable:IEntityBase
    {
        public int Id { get; set; }
        public int TeatcherId { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Dayofweek { get; set; }
        public int SubjectId { get; set; }
        public int RoomId { get; set; }
        public int Permittime { get; set; }
        public DateTime CreatedAt { get; set; }

        public TimeTable()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
