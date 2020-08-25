using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configurations
{
    public class ImagesConfigurations : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.Property(x => x.Image)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(c => c.ArticlesImages)
                .WithOne(ai => ai.Image)
                .HasForeignKey(ai => ai.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

