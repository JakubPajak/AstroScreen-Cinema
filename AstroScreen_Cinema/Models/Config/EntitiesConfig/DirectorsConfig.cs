using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AstroScreen_Cinema.Models.Config.EntitiesConfig
{
	public class DirectorsConfig : IEntityTypeConfiguration<Directors>
    {
        public void Configure(EntityTypeBuilder<Directors> builder)
        {
            throw new NotImplementedException();
        }
    }
}

