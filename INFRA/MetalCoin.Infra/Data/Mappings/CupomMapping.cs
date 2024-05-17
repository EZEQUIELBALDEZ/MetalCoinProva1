using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metalcoin.Core.Domain;

namespace MetalCoin.Infra.Data.Mappings
{
    public class CupomMapping
    {

        public class CupomDescontoMapping : IEntityTypeConfiguration<Cupom>
        {
            public void Configure(EntityTypeBuilder<Cupom> builder)
            {


                builder.HasKey(p => p.Id);

                builder.ToTable("Cupom");

                builder.Property(p => p.CodigoDoCupom).HasColumnType("varchar(1000)").IsRequired();

                builder.Property(p => p.DescricaoDoCupom).HasColumnType("varchar(100)").IsRequired();

                builder.Property(p => p.CuponsLiberados).HasColumnType("varchar(1000)").IsRequired();

                builder.Property(p => p.CuponsUsados).HasColumnType("varchar(1000)").IsRequired();




            }
        }

    }
}
