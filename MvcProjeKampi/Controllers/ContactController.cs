using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contacts = contactManager.GetContacts();
            return View(contacts);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }
    }
}