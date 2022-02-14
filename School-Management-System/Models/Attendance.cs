namespace School_Management_System.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string RoomId { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
