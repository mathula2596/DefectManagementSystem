using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDefect.Controllers
{
    public class ForgotPasswordController : Controller
    {
        Models.LoginDataAccessLayer dtlayer = new Models.LoginDataAccessLayer();

        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }

        // GET: ForgotPassword/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForgotPassword/Create
        public ActionResult Create()
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
            return View();
        }

        // POST: ForgotPassword/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.LoginModel obj = new Models.LoginModel();
                obj.username = collection["username"].ToString();
                obj.password = collection["password"].ToString();
                obj.newpassword = collection["newpassword"].ToString();
                obj.id = int.Parse(collection["id"].ToString());
               

               
                dtlayer.Forgot(obj);
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: ForgotPassword/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForgotPassword/Edit/5
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

        // GET: ForgotPassword/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForgotPassword/Delete/5
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
    }
}