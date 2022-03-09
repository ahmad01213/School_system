
namespace School_Management_System.Data.ViewModels
{
    public class UserForRegister
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string SchoolId { get; set; }
        public string AttendanceNumber { get; set; }
        public string JobNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
       public string Manager { get; set; }

      public UserForRegister(){
          Manager = "-";
      }
    }
}