using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingList = headingManager.GetHeadings();
            return View(headingList);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in categoryManager.GetCategories()
                                               select new SelectListItem
                                               {
                                                   Value = x.CategoryID.ToString(),
                                                   Text = x.CategoryName
                                               }).ToList();
            List<SelectListItem> writers = (from x in writerManager.GetWriters()
                                            select new SelectListItem
                                            {
                                                Value = x.WriterID.ToString(),
                                                Text = x.WriterName + " " + x.WriterSurname
                                            }).ToList();
            ViewBag.categories = categories;
            ViewBag.writers = writers;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categories = (from x in categoryManager.GetCategories()
                                               select new SelectListItem
                                               {
                                                   Value = x.CategoryID.ToString(),
                                                   Text = x.CategoryName
                                               }).ToList();
            ViewBag.categories = categories;
            var heading = headingManager.GetById(id);
            return View(heading);
        }
        
    }
}