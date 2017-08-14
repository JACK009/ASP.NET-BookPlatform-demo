using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BookPlatform.Models;

namespace BookPlatform.EntityConfigurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            Property(b => b.Isbn)
                //unique
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(b => b.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(b => b.Description)
                .IsRequired()
                .HasColumnType("text");

            Property(b => b.Pages)
                .IsRequired()
                .HasColumnType("smallint");

            Property(b => b.PublishingDate)
                .IsRequired();

            HasRequired(b => b.Cover)
                .WithRequiredPrincipal(c => c.Book);

            HasMany(t => t.Tags)
                .WithMany(b => b.Books)
                .Map(c => c.ToTable("BookTags"));
        }
    }
}