using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.EntryServices
{
    public class CreateEntryService
    {
        public void Create(string name, string phoneNumber, int phonebookId)
        {
            using (var db = new Context())
            {
                db.Entry.Add(new DataContext.Core.Domain.Entry
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    PhoneBookId = phonebookId
                });

                db.SaveChanges();
            }
        }
    }
}
