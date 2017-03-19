using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nous.Models
{
    public class NoteTag
    {
        public int NoteId { get; set; }
        public Note Note { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
