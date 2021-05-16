using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var numberOfCategories = context.Categories.Count();
            var numberOfSoftware = context.Headings.Count(x => x.Category.CategoryID == 9);
            var numberOfWriter = context.Writers.Count(x => x.WriterName.Contains("a"));
            var numberOfHeading = context.Headings.Max(x => x.Category.CategoryName);
            var situationIsTrue = context.Categories.Count(x => x.CategoryStatus == true);
            var situationIsFalse = context.Categories.Count(x => x.CategoryStatus == false);
            var situationDifference = situationIsTrue - situationIsFalse;

            ViewBag.numberOfCategories = numberOfCategories;
            ViewBag.numberOfSoftware = numberOfSoftware;
            ViewBag.numberOfWriter = numberOfWriter;
            ViewBag.numberOfHeading = numberOfHeading;
            ViewBag.situationDifference = situationDifference;

            return View();
        }
    }
}