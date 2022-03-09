using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System.Data.ViewModels
{
    public class GetUsersRequest
    {
        public string UserId { get; set; }

        public GetUsersRequest(){
            UserId ="none";
        }
    }
}