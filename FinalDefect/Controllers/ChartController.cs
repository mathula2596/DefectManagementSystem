using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalDefect.Controllers
{
    public class ChartController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult AjaxMethod()
        {
            StringBuilder sb = new StringBuilder();
         

            
            string query = " SELECT COUNT(defect.id) as defect_id, MONTH(status_history.change_date) as month FROM defect inner join  status_history on defect.id = status_history.defect_id WHERE MONTH(status_history.change_date)  = @date GROUP BY  MONTH(status_history.change_date)";
            // string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";

            string constr = "Data Source = MATHULA; Initial Catalog = defect; Integrated Security = True";
           
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                   // for (int i = 0; i < 13; i++)
                    //{
                        cmd.Parameters.AddWithValue("@date", '2');
                    //}
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");
                        while (sdr.Read())
                        {

                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("text :'{0}', value:{1}, color: '{2}'", sdr[0], sdr[1], color));
                            sb.Append("},");
                        }
                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");
                    }

                    con.Close();
                }
            }
            
            
           
            return Content(sb.ToString());
        }
    }
}
