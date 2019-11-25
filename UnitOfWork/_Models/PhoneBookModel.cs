using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork._Models
{
    public class PhoneBookModel
    {
        public int PhoneBookId { get; set; }


        [Required, MaxLength(100)]
        public string Name { get; set; }


        public List<EntryModel> Entries { get; set; }
    }
}
