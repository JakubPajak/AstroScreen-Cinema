using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class CategoriesConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.Description)
                .IsRequired();

            builder.HasMany(m => m.Movies)
                .WithMany(c => c.Categories)
                .UsingEntity<CategoriesAndMovies>(
                w => w.HasOne(m => m.Movies)
                .WithMany()
                .HasForeignKey(k => k.Movie_ID),

                w => w.HasOne(c => c.Categories)
                .WithMany()
                .HasForeignKey(k => k.Category_ID),

                key => key.HasKey(k => new { k.Category_ID, k.Movie_ID })
                );
        }
    }
}

