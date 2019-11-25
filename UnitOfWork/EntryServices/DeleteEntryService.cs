using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.EntryServices
{
    public class DeleteEntryService
    {
        public void Delete(int entryId)
        {
            using(var db = new Context())
            {
                var entry = db.Entry.FirstOrDefault(e => e.EntryId == entryId);

                db.Entry.Remove(entry);

                db.SaveChanges();
            }
        }
    }
}
