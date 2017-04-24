using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Learnike.Models
{
    public static class BaseModelExtensions
    {
        public static void ConfigureBaseRevisionModel<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : BaseModel, IBaseModelRevision
        {
            entity
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getutcdate()");

            entity.HasKey(i => new { i.Id, i.Revision });

            entity.Configure(configure);
        }

        public static void ConfigureBaseModel<T>(this EntityTypeBuilder<T> entity, Action<EntityTypeBuilder<T>> configure = null)
            where T : BaseModel
        {
            entity
                .Property(b => b.CreatedAt)
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
}
