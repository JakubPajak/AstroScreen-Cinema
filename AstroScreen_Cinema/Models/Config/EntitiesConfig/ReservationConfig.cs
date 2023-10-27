using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {



                builder
                .HasOne(r => r.Account)
                .WithMany(a => a.Reservations)
                .HasForeignKey(k => k.Account_ID);


                builder
                .HasOne(r => r.Customer)
                .WithOne(c => c.Reservation)
                .HasForeignKey<Customer>(k => k.Customer_ID);

                builder
                .HasOne(r => r.Seat)
                .WithOne(s => s.Reservation)
                .HasForeignKey<Seats>(k => k.Reservation_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

