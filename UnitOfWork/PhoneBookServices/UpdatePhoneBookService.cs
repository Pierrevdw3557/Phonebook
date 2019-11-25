using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.PhoneBookServices
{
    public class UpdatePhoneBookService
    {
        public void UpdateName(int phonebookId, string name)
        {
            using (var db = new Context())
            {
                var phonebook = db.Phonebook.FirstOrDefault(pb => pb.PhoneBookId == phonebookId);

                phonebook.Name = name;

                db.SaveChanges();
            }
        }
    }
}
