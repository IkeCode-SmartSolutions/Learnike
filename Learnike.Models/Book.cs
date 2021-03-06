﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learnike.Models
{
    public class Book : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        
        public int ApplicationUserId { get; set; }
        
        protected ApplicationUser User { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<BookTag> Tags { get; set; }
    }
}
