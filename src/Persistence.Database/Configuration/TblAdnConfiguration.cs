using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Configuration
{
   
    public class TblAdnConfiguration
    {
        public TblAdnConfiguration(EntityTypeBuilder<TblAdn> entityBuilder)
        {
            entityBuilder.Property(x => x.Adn).IsRequired().HasMaxLength(100);

            entityBuilder.HasIndex(x => x.Adn);
            entityBuilder.HasIndex(x => x.IsMutant);
        }
    }

}
