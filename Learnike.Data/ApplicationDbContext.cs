﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Learnike.Models;
using System.Linq;
using System;
using System.Reflection;

namespace Learnike.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomIdentityRole, int>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Note> Notes { get; set; }

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

            builder.Entity<Book>().ConfigureBaseModel((_) => { });

            builder.Entity<BookTag>().Configure((_) =>
            {
                _.HasKey(k => new { k.BookId, k.TagId });
                _.HasOne(i => i.Book).WithMany(i => i.Tags).HasForeignKey(t => t.BookId);
                _.HasOne(i => i.Tag).WithMany(i => i.Books).HasForeignKey(t => t.TagId);
            });

            builder.Entity<Note>().ConfigureBaseModel((_) => { });

            builder.Entity<Tag>().ConfigureBaseModel((_) => { });

            builder.Entity<NoteTag>().Configure((_) =>
            {
                _.HasKey(k => new { k.NoteId, k.TagId });
                _.HasOne(i => i.Note).WithMany(i => i.Tags).HasForeignKey(t => t.NoteId);
                _.HasOne(i => i.Tag).WithMany(i => i.Notes).HasForeignKey(t => t.TagId);
            });

            builder.Entity<Attachment>().ConfigureBaseModel((_) => { });
        }
    }
}
