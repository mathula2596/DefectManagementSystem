using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class LoginModel
    {
      
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string firstname { get; set; }
        public string newpassword { get; set; }

    }
}
