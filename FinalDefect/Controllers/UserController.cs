using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDefect.Controllers
{
    public class UserController : Controller
    {
        Models.UsersDataAccessLayer dtlayer = new Models.UsersDataAccessLayer();
        Models.LoginDataAccessLayer dtlayerlog = new Models.LoginDataAccessLayer();
        // GET: User
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        public ActionResult Index()
        {
            if(HttpContext.Session.GetString("usertype") ==null )
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

            List<Models.UsersModel> userlist = new List<Models.UsersModel>();
            if (ViewBag.usertype == "Admin")
            {

                //obj.id = ids.ToString();
                //obj.amount = decimal.Parse(collection["amount"]);

                userlist = dtlayer.Refresh().ToList();
                //return View(obj);

            }
            else if (ViewBag.usertype == "Manager")
            {

                //obj.id = ids.ToString();
                //obj.amount = decimal.Parse(collection["amount"]);

                userlist = dtlayer.RefreshManager().ToList();
                //  return View(obj);

            }
            else if (ViewBag.usertype == "Tester")
            {
                //obj.id = ids.ToString();
                //obj.amount = decimal.Parse(collection["amount"]);

                userlist = dtlayer.RefreshTester().ToList();
                //  return View(obj);

            }
            else if (ViewBag.usertype == "Developer")
            {

                //obj.amount = decimal.Parse(collection["amount"]);

                userlist = dtlayer.RefreshDeveloper().ToList();
                //return View(obj);
            }

           
            return View(userlist);
        }

        // GET: User/Details/5
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
            Models.UsersModel obj = new Models.UsersModel();
           
                //obj.id = ids.ToString();
                //obj.amount = decimal.Parse(collection["amount"]);

                obj = dtlayer.FindUser(id);
                //return View(obj);

         

            //  Models.LoginModel objlog = new Models.LoginModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            //objlog = dtlayer.FindLogin(id);
            return View(obj);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("usertype") == null )
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
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here
                Models.UsersModel obj = new Models.UsersModel();
                obj.firstname = collection["firstname"].ToString();
                obj.lastname = collection["lastname"].ToString();
                obj.phone = int.Parse(collection["phone"].ToString());
                obj.email = collection["email"].ToString();
                obj.address = collection["address"].ToString();
                obj.status = collection["status"].ToString();
                obj.username = collection["username"].ToString();
                obj.password = collection["password"].ToString();
                obj.usertype = collection["usertype"].ToString();

                Models.RegisterModel logobj = new Models.RegisterModel();

                logobj.username = collection["username"].ToString();
                logobj.password = collection["password"].ToString();
                logobj.usertype = collection["usertype"].ToString();
                dtlayer.CreateLogin(logobj);
                dtlayer.CreateUser(obj);
                
                


                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("usertype") != "Admin" )
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
            Models.UsersModel obj = new Models.UsersModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            obj = dtlayer.FindUser(id);
          //  Models.LoginModel objlog = new Models.LoginModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            //objlog = dtlayer.FindLogin(id);
            return View(obj);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Models.UsersModel obj = new Models.UsersModel();
                obj.id = int.Parse(collection["id"].ToString());
                obj.firstname = collection["firstname"].ToString();
                obj.lastname = collection["lastname"].ToString();
                obj.phone = int.Parse(collection["phone"]);
                obj.email = collection["email"].ToString();
                obj.address = collection["address"].ToString();
                obj.username = collection["username"].ToString();
                obj.password = collection["password"].ToString();
                obj.usertype = collection["usertype"].ToString();
                obj.status = collection["status"].ToString();
                dtlayer.EditUser(obj);
                return RedirectToAction("Index");
                //return Redirect();
                /* Models.LoginModel objlog = new Models.LoginModel();
                 objlog.id = int.Parse(collection["id"].ToString());
                 objlog.username = collection["username"].ToString();
                 objlog.password = collection["password"].ToString();
                 objlog.usertype = collection["usertype"].ToString();

                 dtlayer.EditUser(obj);*/
                //dtlayer.EditLogin(obj);

            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
    
    }
}