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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CricketerService(userId);
            service.CreateCricketer(model);

            return RedirectToAction("Index");


        }




    }
}