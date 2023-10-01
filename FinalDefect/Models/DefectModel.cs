using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDefect.Models
{
    public class DefectModel 
    {
        public int id { get; set; }
        public string description { get; set; }
       
        public string status { get; set; }
        public string assign_to { get; set; }
        public string project_name { get; set; }
        public string change_date { get; set; }
        public int defect_id { get; set; }
        public string user_id { get; set; }
     //'   public string firstname { get; set; }
        public  IEnumerable<SelectListItem> firstname { get; set; }
       
        

       
      //  public List<UsersModel> usersModels { get; set; }

       // DatabaseContext _context = new DatabaseContext();



    }
}
