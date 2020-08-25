using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configurations
{
    public class RatesConfigurations : IEntityTypeConfiguration<Rates>
    {
        public void Configure(EntityTypeBuilder<Rates> builder)
        {

            builder.HasMany(c => c.ArticlesRates)
                .WithOne(ai => ai.Rate)
                .HasForeignKey(ai => ai.RateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}