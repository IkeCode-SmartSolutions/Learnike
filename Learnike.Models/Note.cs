using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learnike.Models
{
    [Revision]
    public class Note : BaseModel, IBaseModelRevision
    {
        public int Revision { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Favorite { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public IEnumerable<NoteTag> Tags { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
