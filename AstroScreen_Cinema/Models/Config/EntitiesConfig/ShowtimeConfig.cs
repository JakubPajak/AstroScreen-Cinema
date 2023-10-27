using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class ShowtimeConfig : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
                builder
                .HasMany(r => r.Reservations)
                .WithOne(sh => sh.Showtime)
                .HasForeignKey(k => k.Reservation_ID);
        }
    }
}

