using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.EntryServices;

namespace Phonebook_Application.Controllers.Entry
{
    public class UpdateEntryController : Controller
    {
        readonly UpdateEntryService updateEntry;

        public UpdateEntryController()
        {
            updateEntry = new UpdateEntryService();
        }

        public JsonResult UpdateName(int entryId, string name)
        {
            updateEntry.UpdateName(entryId, name);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePhoneNumber(int entryId, string phoneNumber)
        {
            updateEntry.UpdatePhoneNumber(entryId, phoneNumber);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}