using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nous.Web.Models;

namespace Nous.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomIdentityRole, int>
    {
        public DbSet<Book> Books { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            var book = builder.Entity<Book>();
            book.Property(b => b.Created)
                .HasDefaultValueSql("getutcdate()");
            book.Property(b => b.Updated)
                .HasDefaultValueSql("getutcdate()");

            var note = builder.Entity<Note>();
            note.Property(b => b.Created)
                .HasDefaultValueSql("getutcdate()");
            note.Property(b => b.Updated)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
