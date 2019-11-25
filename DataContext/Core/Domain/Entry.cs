using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Core.Domain
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(14), Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("PhoneBook")]
        public int PhoneBookId { get; set; }

        //Many to one relationship
        public virtual PhoneBook PhoneBook { get; set; }
    }
}
