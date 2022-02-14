using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Room:IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int SubjectId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Room()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
