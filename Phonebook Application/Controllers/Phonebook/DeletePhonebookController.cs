using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.PhoneBookServices;

namespace Phonebook_Application.Controllers.Phonebook
{
    public class DeletePhonebookController : Controller
    {
        DeletePhoneBookService deletePhonebook;

        public DeletePhonebookController()
        {
            deletePhonebook = new DeletePhoneBookService();
        }

        public JsonResult Delete(int phonebookId)
        {
            deletePhonebook.Delete(phonebookId);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}