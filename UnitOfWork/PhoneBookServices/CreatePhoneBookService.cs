using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.PhoneBookServices
{
    public class CreatePhoneBookService
    {
        public void Create(string name)
        {
            using(var db = new Context())
            {
                db.Phonebook.Add(new DataContext.Core.Domain.PhoneBook
                {
                    Name = name
                });

                db.SaveChanges();
            }
        }
    }
}
