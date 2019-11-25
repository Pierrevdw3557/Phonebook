using DataContext.Core.Domain;
using DataContext.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork._Models;

namespace UnitOfWork.EntryServices
{
    public class ReturnEntryService
    {
        public bool Exists(string name, int phonebookId)
        {
            using (var db = new Context())
            {
                return db.Entry.Any(e => e.Name.ToLower() == name.ToLower() && e.PhoneBookId == phonebookId);
            }
        }
    }
}
