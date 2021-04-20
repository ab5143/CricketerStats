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




    }
}