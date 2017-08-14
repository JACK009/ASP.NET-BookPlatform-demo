using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BookPlatform.Models;

namespace BookPlatform.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, 
                new IndexAnnotation(
                    new IndexAttribute("IX_Tag", 1)
                    {
                        IsUnique = true
                    })
                )
                .HasMaxLength(255);
        }
    }
}