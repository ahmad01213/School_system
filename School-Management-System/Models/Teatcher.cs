using School_Management_System.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Teatcher:IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int SchoolId { get; set; }
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public int CardNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public Teatcher()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
