using DataContext.Core.Domain;
using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork._Models;

namespace UnitOfWork.PhoneBookServices
{
    public class ReturnPhoneBookService
    {
        public List<PhoneBookModel> GetAll()
        {
            using (var db = new Context())
            {
                return db.Phonebook.Select(pb => new PhoneBookModel
                {
                    PhoneBookId = pb.PhoneBookId,
                    Name = pb.Name,
                    Entries = pb.Entries.Select(e => new EntryModel
                    {
                        EntryId = e.EntryId,
                        Name = e.Name,
                        PhoneNumber = e.PhoneNumber
                    }).ToList()
                }).ToList();
            }
        }

        public PhoneBookModel GetById(int id)
        {
            using (var db = new Context())
            {
                var result = db.Phonebook.Include(e => e.Entries).FirstOrDefault(pb => pb.PhoneBookId == id);

                return new PhoneBookModel
                {
                    PhoneBookId = result.PhoneBookId,
                    Name = result.Name,
                    Entries = result.Entries.Select(e => new EntryModel
                    {
                        EntryId = e.EntryId,
                        Name = e.Name,
                        PhoneNumber = e.PhoneNumber
                    }).ToList()
                };
            };
        }
    }
}
