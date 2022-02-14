using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class School:IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string City { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Manager { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public School()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
