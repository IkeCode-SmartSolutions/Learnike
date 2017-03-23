using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learnike.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }

        public IEnumerable<NoteTag> Notes { get; set; }
    }
}
