using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class RegisterModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
    }
}
