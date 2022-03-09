using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Room:IEntityBase
    {
        public int Id { get; set; }

        public string RoomId { get; set; }


        public string SchoolId { get; set; }
        public string Roomip { get; set; }

        public int SubjectId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Room()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
