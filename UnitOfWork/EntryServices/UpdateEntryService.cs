using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.EntryServices
{
    public class UpdateEntryService
    {
        public void UpdateName(int entryId, string name)
        {
            using (var db = new Context())
            {
                var entry = db.Entry.FirstOrDefault(pb => pb.EntryId == entryId);

                entry.Name = name;

                db.SaveChanges();
            }
        }

        public void UpdatePhoneNumber(int entryId, string number)
        {
            using (var db = new Context())
            {
                var entry = db.Entry.FirstOrDefault(pb => pb.EntryId == entryId);

                entry.PhoneNumber = number;

                db.SaveChanges();
            }
        }
    }
}
