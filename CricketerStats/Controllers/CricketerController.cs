using CrickerStats.Services;
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
    public class CricketerController : Controller
    {
        // GET: Cricketer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CricketerService(userId);
            var model = service.GetCricketers();

            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CricketerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCricketService();

            if (service.CreateCricketer(model))
            {
                TempData["SaveResult"] = "Your Cricketer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Cricketer could not be created.");

            return View(model);

        }

        private CricketerService CreateCricketService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CricketerService(userId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateCricketService();
            var model = svc.GetCricketerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)

        {
            var service = CreateCricketService();
            var detail = service.GetCricketerById(id);
            var model =
                new CricketerEdit
                {
                    Name = detail.Name,
                    Country = detail.Country,
                    TotalRuns = detail.TotalRuns,
                    CricketerId = detail.CricketerId
                };
            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CricketerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CricketerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateCricketService();

            if (service.UpdateCricketer(model))
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
            var svc = CreateCricketService();
            var model = svc.GetCricketerById(id);

            return View(model);
        }




        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCricketService();

            service.DeleteCricketer(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");



        }
    }
}
