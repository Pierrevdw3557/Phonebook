using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.PhoneBookServices;

namespace Phonebook_Application.Controllers.Phonebook
{
    public class CreatePhonebookController : Controller
    {
        readonly CreatePhoneBookService createPhonebook;

        public CreatePhonebookController() 
        {
            createPhonebook = new CreatePhoneBookService();
        }

        public JsonResult Create(string name)
        {
            createPhonebook.Create(name);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}