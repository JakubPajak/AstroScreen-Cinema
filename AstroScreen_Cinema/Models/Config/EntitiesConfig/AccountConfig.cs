using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class AccountConfig : IEntityTypeConfiguration<Account>
	{

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Birthdate)
                .IsRequired();

            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.PhoneNum)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

