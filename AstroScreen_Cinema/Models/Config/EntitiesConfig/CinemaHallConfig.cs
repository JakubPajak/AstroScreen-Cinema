using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
    {

        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {

            builder.Property(ch => ch.NumOfSeats)
            .IsRequired();

            builder.Property(ch => ch.RowNum)
                .IsRequired();

            builder.Property(ch => ch.SeatNum)
                .IsRequired();

            builder.Property(ch => ch.NumOfSeats)
                .IsRequired();

            builder
                .HasMany(s => s.Seats)
                .WithOne(h => h.CinemaHall)
                .HasForeignKey(k => k.Hall_ID);

                builder
                .HasMany(sh => sh.Showtimes)
                .WithOne(h => h.CinemaHall)
                .HasForeignKey(k => k.Showtime_ID);
        }
    }
}

