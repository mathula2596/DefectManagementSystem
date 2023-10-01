using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalDefect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalDefect.Controllers
{
    public class LoginController : Controller
    {
          
        Models.LoginDataAccessLayer dtlayer = new Models.LoginDataAccessLayer();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

       

        // GET: Login/Details/5
        public ActionResult Details(string username, string password)
        {
            Models.LoginModel obj = new Models.LoginModel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            obj = dtlayer.Find(username,password);
            return View(obj);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {

            try
            {
                // TODO: Add delete logic here
                if(ModelState.IsValid)
                {
                    LoginModel objModel = new LoginModel();
                    UsersModel usersModel = new UsersModel();
                    string username = collection["username"];
                    string password = collection["password"];
                    objModel = dtlayer.Find(username, password);
                    if(objModel !=null && objModel.usertype!=null)
                    {
                        if(objModel.usertype=="Admin" || objModel.usertype == "Tester" || objModel.usertype == "Manager" || objModel.usertype == "Developer")
                        {
                            HttpContext.Session.SetString("username", objModel.username);
                            HttpContext.Session.SetString("usertype", objModel.usertype.ToString());
                            HttpContext.Session.SetString("id", objModel.id.ToString());
                            HttpContext.Session.SetString("firstname", objModel.firstname.ToString());
                            ViewBag.id = HttpContext.Session.GetString("id");
                            string id = ViewBag.id;
                            // HttpContext.Current.Session["sessionString"] = sessionValue;
                            //this.Session["UserProfile"] = profileData;
                            return RedirectToAction("Details/"+id, "User");
                            

                        }
                       
                        else
                        {

                            ViewBag.ErrorMsg = "You don't have permission";
                            return View();
                          
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Check your username or password!!!";
                        return View();
                    }
                }
                

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ErrorViewModel er = new ErrorViewModel();
                er.RequestId = ex.ToString();
                return View("~/Views/Shared/Error.cshtml", er);
             
                // View();
            }
        }

        [HttpGet]
        
        public ActionResult Logout()
        {
            var myCookies = Request.Cookies.Keys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies.Delete(cookie, new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Domain = "auth.example.com"
                });
            }

            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("usertype");
            HttpContext.Session.Remove("firstname");
            return RedirectToAction("Login/Login");
           
        }


    }
}
       

