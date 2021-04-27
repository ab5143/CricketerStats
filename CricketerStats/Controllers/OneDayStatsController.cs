using CrickerStats.Services;
using CricketerStats.Data;
using CricketerStats.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricketerStats.Controllers
{

    [Authorize]
    public class OneDayStatsController : Controller
    {

        // GET: Cricketer
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new OneDayStatsServices(userId);
            //var model = service.GetOneDayStatsByCricketer(id);

            var service = CreateOneDayService();
            var model = service.GetOneDayStats();
            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OneDayStatsCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateOneDayService();

            if (service.CreateOneDayStats(model))
            {
                //TempData["SaveResult"] = "Your Cricketer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Cricketer could not be created.");

            return View(model);

        }

        private OneDayStatsServices CreateOneDayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OneDayStatsServices(userId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateOneDayService();
            var model = svc.GetOneDayStatsByCricketer(id);

            return View(model);
        }

        public ActionResult Edit(int id)

        {
            var service = CreateOneDayService();
            var detail = service.GetOneDayStatsEditById(id);
            var model =
                new OneDayStatsEdit
                {
                    WicketOneDayInt = detail.WicketOneDayInt,
                    CenturyOneDayInt = detail.CenturyOneDayInt,
                    HatrickOneDayInt = detail.HatrickOneDayInt,
                    CricketerId = detail.CricketerId,
                    OneDayIntId = detail.OneDayIntId
                    
                   
                };
            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OneDayStatsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OneDayIntId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateOneDayService();

            if (service.UpdateOneDayStats(model))
            {
                TempData["SaveResult"] = "Your Cricketer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Cricketer could not be updated.");
            return View(model);
        }



        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOneDayService();
            var model = svc.GetOneDayStatsEditById(id);

            return View(model);
        }




        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOneDayService();

            service.DeleteOneDayStats(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");

        }

    }
}
