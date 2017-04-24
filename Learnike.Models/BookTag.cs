using System;

namespace Learnike.Models
{
    public class BookTag : BaseModel, IBaseModelRevision
    {
        public int Revision { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
