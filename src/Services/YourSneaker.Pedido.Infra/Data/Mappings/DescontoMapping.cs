﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Pedido.Domain.Descontos;

namespace YourSneaker.Pedido.Infra.Data.Mappings
{
    public class DescontoMapping : IEntityTypeConfiguration<Desconto>
    {
        public void Configure(EntityTypeBuilder<Desconto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Descontos");
        }
    }
}
