using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.EntryServices;

namespace Phonebook_Application.Controllers.Entry
{
    public class CreateEntryController : Controller
    {
        readonly CreateEntryService createEntry;

        public CreateEntryController()
        {
            createEntry = new CreateEntryService();
        }

        public JsonResult Create(string name, string phoneNumber, int phonebookId)
        {
            createEntry.Create(name, phoneNumber, phonebookId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}