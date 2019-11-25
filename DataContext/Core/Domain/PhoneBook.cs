using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Core.Domain
{
    public class PhoneBook
    {
        [Key]
        public int PhoneBookId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        

        //One to Many relationship
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
