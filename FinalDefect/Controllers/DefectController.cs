using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalDefect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalDefect.Controllers
{
    public class DefectController : Controller
    {
       // private DataEntryContext _context;

        Models.DefectDataAccessLayer dtlayer = new Models.DefectDataAccessLayer();
        // GET: Defect
        public ActionResult Index()
        {

            if (HttpContext.Session.GetString("usertype") == null)
            {
                // _session.SetString("Test", "Ben Rules!");
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.ErrorMsg = "don't have access";
            }
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.id = HttpContext.Session.GetString("id");
            ViewBag.usertype = HttpContext.Session.GetString("usertype");
            List<Models.DefectModel> defectlist = new List<Models.DefectModel>();
            defectlist = dtlayer.Refresh().ToList();
            return View(defectlist);
        }

        // GET: Defect/Details/5
        public ActionResult Details(int id)
        {

            if (HttpContext.Session.GetString("usertype") ==null)
            {
                // _session.SetString("Test", "Ben Rules!");
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.ErrorMsg = "don't have access";
            }
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.id = HttpContext.Session.GetString("id");
            ViewBag.usertype = HttpContext.Session.GetString("usertype");
            Models.DefectModel obj = new Models.DefectModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            obj = dtlayer.Find(id);
            //  Models.LoginModel objlog = new Models.LoginModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            //objlog = dtlayer.FindLogin(id);
            return View(obj);
        }

        // GET: Defect/Create
        public ActionResult Create()
        {
            ViewBag.usertype = HttpContext.Session.GetString("usertype");
            if (ViewBag.usertype == null)
            {
                // _session.SetString("Test", "Ben Rules!");
                //ViewBag.ErrorMsg = "don't have access";
                return RedirectToAction("Login", "Login");
                

            }
              string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";

                SqlConnection con = new SqlConnection(con_string);

                //con.Open();
                SqlDataAdapter _da = new SqlDataAdapter("select * from users inner join login on users.id=login.id where login.usertype='Developer'", con);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);
                ViewBag.NameList = ToSelectList(_dt, "id", "firstname");

            ViewBag.ErrorMsg = "don't have access";
                ViewBag.username = HttpContext.Session.GetString("username");
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.id = HttpContext.Session.GetString("id");
                ViewBag.usertype = HttpContext.Session.GetString("usertype");
            /*  var firstname = dtlayer.Fname()
                  .Select(s => new SelectListItem
                  {
                      Value = s, // this will be the value of the dropdown
                      Text = s  // this will be the visible text in the dropdown
                  });*/
            //ViewBag.name = dtlayer.Fname();
           

                List<Models.DefectModel> defectlist = new List<Models.DefectModel>();
               // defectlist = dtlayer.Fname().ToList();
               // ViewBag.name = defectlist;
               
                return View();
          
           
        }

        // POST: Defect/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                /*Models.DefectHistoryModel objhistory = new Models.DefectHistoryModel();
                 objhistory.id = int.Parse(collection["id"]);
                 objhistory.status = collection["status"].ToString();
                 objhistory.user_id = collection["id"].ToString();*/
           

                Models.DefectModel obj = new Models.DefectModel();
                obj.project_name = collection["project_name"].ToString();
                obj.description = collection["description"].ToString();
                obj.assign_to = collection["assign_to"].ToString();
                obj.status = collection["status"].ToString();
                obj.user_id = collection["user_id"].ToString();
                ///Models.UsersDataAccessLayer userlayer = new Models.UsersDataAccessLayer();
                //obj.usersModels = userlayer.Refresh().ToList();
                // obj.id = int.Parse(collection["id"]);
                // dtlayer.Findid();


                // dtlayer.CreateHistory(objhistory);
                dtlayer.Create(obj);
                


                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Defect/Edit/5
        public ActionResult Edit(int id)
        {

            if (HttpContext.Session.GetString("usertype") ==null)
            {
                // _session.SetString("Test", "Ben Rules!");
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.ErrorMsg = "don't have access";
            }
            string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";

            SqlConnection con = new SqlConnection(con_string);

            //con.Open();
            SqlDataAdapter _da = new SqlDataAdapter("select * from users inner join login on users.id=login.id where login.usertype='Developer'", con);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.NameList = ToSelectList(_dt, "id", "firstname");
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.id = HttpContext.Session.GetString("id");
            ViewBag.usertype = HttpContext.Session.GetString("usertype");
            Models.DefectModel obj = new Models.DefectModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            obj = dtlayer.Find(id);

            //  Models.LoginModel objlog = new Models.LoginModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            //objlog = dtlayer.FindLogin(id);
            return View(obj);
        }

        // POST: Defect/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Models.DefectModel obj = new Models.DefectModel();
                obj.id = int.Parse(collection["id"].ToString());
                obj.project_name = collection["project_name"].ToString();
                obj.description = collection["description"].ToString();
                obj.status = collection["status"].ToString();
                obj.assign_to = collection["email"].ToString();
                obj.user_id = collection["user_id"].ToString();
                obj.assign_to = collection["assign_to"].ToString();
                dtlayer.Edit(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Defect/Delete/5
     

        // POST: Defect/Delete/5
       

        
       /* public ActionResult Fname()
        {
            string con_string = "Data Source=MATHULA;Initial Catalog=defect;Integrated Security=True";

            SqlConnection con = new SqlConnection(con_string);
            
                //con.Open();
                SqlDataAdapter _da = new SqlDataAdapter("select * from users inner join login on users.id=login.id where login.usertype='Developer'", con);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);
                ViewBag.NameList = ToSelectList(_dt, "id", "firstname");
               
               // con.Close();
            
            return View();

        }
       /* public ActionResult MemberEntry()
        {
            string constr = ConfigurationManager.ConnectionStrings["mbkConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From tblCities", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.CityList = ToSelectList(_dt, "CityID", "CityName");

            return View();
        }*/

      /*  [HttpPost]
        public ActionResult Fname(DefectModel _member)
        {
            return View();
        }*/

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            ViewBag.SelectedItem = list;
          //  ViewBag.NameList = ToSelectList(_dt, "id", "firstname");
            return new SelectList(list, "Value", "Text");
        }

      

    }
}