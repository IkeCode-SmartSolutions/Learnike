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
            entity.Property(b => b.Created)
                .HasDefaultValueSql("getutcdate()");
            entity.Property(b => b.Updated)
                .HasDefaultValueSql("getutcdate()");

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Updated { get; set; }
    }
}