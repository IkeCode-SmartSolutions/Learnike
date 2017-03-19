using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learnike.Models
{
    public class Note : BaseFileModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Favorite { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public IEnumerable<NoteTag> Tags { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
