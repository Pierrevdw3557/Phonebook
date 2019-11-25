using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.EntryServices;
using UnitOfWork.PhoneBookServices;

namespace Phonebook_Application.Controllers.Entry
{
    public class ShowEntryController : Controller
    {
        readonly ReturnEntryService entry;
        readonly ReturnPhoneBookService phonebook;

        public ShowEntryController()
        {
            entry = new ReturnEntryService();
            phonebook = new ReturnPhoneBookService();
        }

        public ActionResult Index(int phonebookId)
        {
            return View("~/Views/Entry/Index.cshtml", phonebook.GetById(phonebookId));
        }

        public ActionResult NewEntry()
        {
            return PartialView("~/Views/Entry/_NewEntryDialog.cshtml");
        }

        public JsonResult ExistingEntry(string name, int phonebookId)
        {
            return Json(new { Success = entry.Exists(name, phonebookId) }, JsonRequestBehavior.AllowGet);
        }
    }
}