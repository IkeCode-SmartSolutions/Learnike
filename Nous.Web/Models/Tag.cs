using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nous.Web.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }

        public IEnumerable<NoteTag> Notes { get; set; }
    }
}
