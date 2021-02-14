using AssignMVCRestaurantCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignMVCRestaurantCRUD.Controllers
{
    public class HomeController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();


        public ActionResult Index(string search="")
        {
            // var rest =db.RestaurantTabs.ToList();
            //search with the condition
            ViewBag.Search = search;
            var rest = db.RestaurantTabs.Where(r => r.Name.Contains(search)).ToList();

            return View(rest);
        }

        public ActionResult Details(int id)
        {
            var res = db.RestaurantTabs.Where(r => r.Id == id).FirstOrDefault();

            return View(res);

        }
        public ActionResult Create()
        {
            ViewBag.rset = db.RestaurantTabs.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantTab restaurantTab)
        {
           db.RestaurantTabs.Add(restaurantTab);
          db.SaveChanges(); 
           return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var resToUpdate = db.RestaurantTabs.Where(r => r.Id == id).FirstOrDefault();
            return View(resToUpdate);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantTab restaurantTab)
        {
            var UpdatedRes = db.RestaurantTabs.Where(r => r.Id ==restaurantTab.Id).FirstOrDefault();
            UpdatedRes.Name = restaurantTab.Name;
            UpdatedRes.Type = restaurantTab.Type;
          //  UpdatedRes.Id = restaurantTab.Id;
            db.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
         var del= db.RestaurantTabs.Where(r => r.Id == id).FirstOrDefault();
            return View(del);
        }


        [HttpPost]
        public ActionResult Delete(int id,RestaurantTab restaurantTab)
        {
            var del = db.RestaurantTabs.Where(r => r.Id == id).FirstOrDefault();
            db.RestaurantTabs.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Image()
        {
            return View();
        }


        /*  public ActionResult About()
          {
              ViewBag.Message = "Your application description page.";

              return View();
          }

          public ActionResult Contact()
          {
              ViewBag.Message = "Your contact page.";

              return View();
          }


          */
    }
}