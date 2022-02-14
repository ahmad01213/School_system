using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Class:IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public Class()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
