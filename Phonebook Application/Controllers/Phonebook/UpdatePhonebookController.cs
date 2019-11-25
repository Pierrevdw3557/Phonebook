using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.PhoneBookServices;

namespace Phonebook_Application.Controllers.Phonebook
{
    public class UpdatePhonebookController : Controller
    {
        UpdatePhoneBookService updatePhonebook;

        public UpdatePhonebookController()
        {
            updatePhonebook = new UpdatePhoneBookService();
        }

        public JsonResult UpdateName(int phonebookId, string name)
        {
            updatePhonebook.UpdateName(phonebookId, name);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}