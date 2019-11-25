using Phonebook_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork._Models;
using UnitOfWork.PhoneBookServices;

namespace Phonebook_Application.Controllers.Phonebook
{
    [RoutePrefix("Phonebook")]
    public class ShowPhonebookController : Controller
    {
        private readonly ReturnPhoneBookService phoneBook;

        public ShowPhonebookController()
        {
            phoneBook = new ReturnPhoneBookService();
        }

        public ActionResult Index()
        {
            return View("~/Views/Phonebook/Index.cshtml", phoneBook.GetAll());
        }

        public ActionResult NewPhoneBook()
        {
            return PartialView("~/Views/Phonebook/_NewPhonebookDialog.cshtml");
        }

        public ActionResult ViewPhoneBook(int id)
        {
            return View(phoneBook.GetById(id));
        }
    }
}