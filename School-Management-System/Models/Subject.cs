using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Subject : IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }

        public string SchoolId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Subject() {
            CreatedAt = DateTime.Now;
            SchoolId = "1";
        }
    }
}
