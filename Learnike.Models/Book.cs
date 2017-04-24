using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learnike.Models
{
    [Revision]
    public class Book : BaseModel, IBaseModelRevision
    {
        public int Revision { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<BookTag> Tags { get; set; }
    }
}
