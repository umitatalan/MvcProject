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
    public class StatisticsController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            List<Category> allCategories = categoryManager.GetCategories();
            ViewBag.allCategoriesCount = allCategories.Count;

            List<Heading> allHeadings = headingManager.GetHeadings();
            ViewBag.headingCountBySoftwareCategory = allHeadings
                .Where(p => p.Category.CategoryName == "Yazılım")
                .ToList().Count;

            List<Writer> allWriters = writerManager.GetWriters();
            var writers = allWriters
                .Where(p => p.WriterName.ToLower().Contains("a"))
                .ToList();
            ViewBag.writersWithALetterInTheirName = writers.Count;

            var heading = allHeadings
                .GroupBy(p => p.CategoryID)
                .OrderByDescending(p => p.Count())
                .Select(p => p.FirstOrDefault());
            ViewBag.categoryWithTheMostTitles = heading.FirstOrDefault().Category.CategoryName;

            ViewBag.categoryDifferent = allCategories.Where(p => p.CategortStatus).Count() - allCategories.Where(p => !p.CategortStatus).Count();

            return View(ViewBag);
        }
    }
}