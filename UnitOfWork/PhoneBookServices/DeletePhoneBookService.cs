using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.PhoneBookServices
{
    public class DeletePhoneBookService
    {
        public void Delete(int id)
        {
            using(var db = new Context())
            {
                var phonebook = db.Phonebook.FirstOrDefault(pb => pb.PhoneBookId == id);

                db.Phonebook.Remove(phonebook);

                db.SaveChanges();
            }
        }
    }
}
