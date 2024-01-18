﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Configurations
{
    public class SiparisDetayConfiguration : IEntityTypeConfiguration<SiparisDetay>
    {
        public void Configure(EntityTypeBuilder<SiparisDetay> builder)
        {
            builder.HasKey(k => k.SiparisDetayId);
            builder.Property(k => k.SiparisDetayId).IsRequired();
            builder.Property(k => k.SiparisId).IsRequired();
            builder.Property(k => k.UrunId).IsRequired();
            builder.Property(k => k.UrunAdet).IsRequired();
            builder.Property(k => k.BirimFiyat).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
