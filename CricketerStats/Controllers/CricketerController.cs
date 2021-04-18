using CricketerStats.Models;
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
            var model = new CricketerList[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CricketerCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }




    }
}