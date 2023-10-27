using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
                builder
                .HasOne(d => d.Director)
                .WithMany(m => m.Movies)
                .HasForeignKey(k => k.Director_ID);

                builder
                .HasOne(m => m.Showtime)
                .WithOne(sh => sh.Movie)
                .HasForeignKey<Showtime>(sh => sh.Showtime_ID)
                .OnDelete(DeleteBehavior.Restrict);


                builder
                .HasMany(a => a.Actors)
                .WithMany(m => m.Movies)
                .UsingEntity<ActorsInMovies>(
                    w => w.HasOne(wit => wit.Actor)
                    .WithMany()
                    .HasForeignKey(a => a.Actor_ID),

                    w => w.HasOne(wit => wit.Movie)
                    .WithMany()
                    .HasForeignKey(m => m.Movie_ID),

                    wit => wit.HasKey(x => new { x.Movie_ID, x.Actor_ID })
                    );
        }
    }
}

