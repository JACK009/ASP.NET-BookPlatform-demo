using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BookPlatform.Models;

namespace BookPlatform.EntityConfigurations
{
    public class CoverConfiguration : EntityTypeConfiguration<Cover>
    {
        public CoverConfiguration()
        {
            Property(c => c.ImageUrl)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255);
        }
    }
}