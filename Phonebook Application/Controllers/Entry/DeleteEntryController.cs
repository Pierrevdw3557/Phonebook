using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.EntryServices;

namespace Phonebook_Application.Controllers.Entry
{
    public class DeleteEntryController : Controller
    {
        readonly DeleteEntryService deleteEntry;

        public DeleteEntryController()
        {
            deleteEntry = new DeleteEntryService();
        }

        public JsonResult Delete(int entryId)
        {
            deleteEntry.Delete(entryId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}