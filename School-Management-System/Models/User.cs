using Microsoft.AspNetCore.Identity;

namespace School_Management_System.Models
{
    public class User:IdentityUser
    {
      public string Role { get; set; }
      public string Phone { get; set; }
      public string SchoolId { get; set; }
      public string AttendanceNumber { get; set; }
      public string JobNumber { get; set; }
      public string Name { get; set; }
      public string Manager { get; set; }

      public User(){
          Manager = "-";
      }
    }
}
