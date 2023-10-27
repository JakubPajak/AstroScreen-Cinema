using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class ActorsConfig : IEntityTypeConfiguration<Actors>
	{
        public void Configure(EntityTypeBuilder<Actors> builder)
        {
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

