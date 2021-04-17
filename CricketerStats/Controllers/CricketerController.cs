using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricketerStats.Controllers
{
    public class CricketerController : Controller
    {
        // GET: Cricketer
        public ActionResult Index()
        {
            return View();
        }
    }
}