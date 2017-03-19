using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nous.Models
{
    public class Book : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        
        public int ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}
