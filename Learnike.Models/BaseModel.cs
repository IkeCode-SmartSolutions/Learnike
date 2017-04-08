using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learnike.Models
{
    public static class BaseModelHelper
    {
        public static void ConfigureBaseModel<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : BaseModel
        {
            entity.Property(b => b.CreatedAt)
                .HasDefaultValueSql("getutcdate()");

            entity.HasKey(i => i.Id);
            
            entity.Configure(configure);
        }

        public static void Configure<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : class
        {
            configure?.Invoke(entity);
        }
    }

    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int UID { get; set; }

        public int Revision { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public EntryState EntryState { get; set; }

        public ApplicationUser LockedBy { get; set; }
    }
}