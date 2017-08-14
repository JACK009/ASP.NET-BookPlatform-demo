using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BookPlatform.Models;

namespace BookPlatform.EntityConfigurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");

            Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");

            Ignore(a => a.FullName);

            Property(a => a.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);
        }
    }
}