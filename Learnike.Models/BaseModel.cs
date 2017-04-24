using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learnike.Models
{
    public class BaseModel : IBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; }
        public int OwnerId { get; set; }

        public ApplicationUser LockedBy { get; set; }
    }

    public interface IBaseModel
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        ApplicationUser Owner { get; set; }
        int OwnerId { get; set; }

        ApplicationUser LockedBy { get; set; }
    }

    public interface IBaseModelRevision
    {
        int Revision { get; set; }
    }
}