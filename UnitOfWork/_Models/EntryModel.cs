using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork._Models
{
    public class EntryModel
    {
        public int EntryId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }
    }
}
