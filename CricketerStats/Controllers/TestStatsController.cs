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
    public class TestStatsController : Controller
    {

        // GET: Cricketer
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new OneDayStatsServices(userId);
            //var model = service.GetOneDayStatsByCricketer(id);

            var service = CreateTestService();
            var model = service.GetTestStats();
            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestStatsCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateTestService();

            if (service.CreateTestStats(model))
            {
                //TempData["SaveResult"] = "Your Cricketer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Cricketer could not be created.");

            return View(model);

        }

        private TestStatsServices CreateTestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TestStatsServices(userId);
            return service;
        }


        public ActionResult Details(int id)
        {
            var svc = CreateTestService();
            var model = svc.GetTestStatsByCricketer(id);

            return View(model);
        }

        public ActionResult Edit(int id)

        {
            var service = CreateTestService();
            var detail = service.GetTestStatsEditById(id);
            var model =
                new TestStatsEdit
                {
                    TestId = detail.TestId,
                    DoubleCenturyTest = detail.DoubleCenturyTest,
                    HalfCenturyTest = detail.HalfCenturyTest,
                    CricketerId = detail.CricketerId
                    


                };
            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TestStatsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TestId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateTestService();

            if (service.UpdateTestStats(model))
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
            var svc = CreateTestService();
            var model = svc.GetTestStatsEditById(id);

            return View(model);
        }




        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTestService();

            service.DeleteTestStats(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");

        }

    }
}