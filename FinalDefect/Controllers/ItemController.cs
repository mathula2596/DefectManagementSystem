using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDefect.Controllers
{
    public class ItemController : Controller
    {
        Models.ItemDataAccessLayer dtlayer = new Models.ItemDataAccessLayer();
        // GET: Item
        
        public ActionResult Index()
        {
            List<Models.ItemModdel> itemlist = new List<Models.ItemModdel>();
            itemlist = dtlayer.Refresh().ToList();
            return View(itemlist);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.ItemModdel obj = new Models.ItemModdel();
                obj.name = collection["name"].ToString();
                obj.amount = decimal.Parse(collection["amount"]);

                dtlayer.Create(obj);



                return RedirectToAction(nameof(Index));
            
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {

           // int ids = id;
            Models.ItemModdel obj = new Models.ItemModdel();
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            obj = dtlayer.Find(id);
            return  View(obj);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.ItemModdel obj = new Models.ItemModdel();
                obj.id = int.Parse(collection["id"].ToString());
                obj.name = collection["name"].ToString();
                obj.amount = decimal.Parse(collection["amount"]);

                dtlayer.Edit(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            int ids = id;
            Models.ItemModdel obj = new Models.ItemModdel();
            obj.id = id;
        

           // dtlayer.Delete(obj);
            //obj.id = ids.ToString();
            //obj.amount = decimal.Parse(collection["amount"]);

            // dtlayer.Delete(ids);
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.ItemModdel obj = new Models.ItemModdel();
                obj.id = int.Parse(collection["id"].ToString());
                obj.name = collection["name"].ToString();
                obj.amount = decimal.Parse(collection["amount"]);

                dtlayer.Delete(obj);
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}