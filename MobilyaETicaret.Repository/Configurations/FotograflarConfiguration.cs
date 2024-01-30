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
    public class FotograflarConfiguration : IEntityTypeConfiguration<Fotograflar>
    {
        public void Configure(EntityTypeBuilder<Fotograflar> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.AktifMi).IsRequired(true);
            builder.Property(k => k.EklenmeTarih).IsRequired(true);
            builder.Property(k => k.FotografAdi).IsRequired(false);
            builder.Property(k => k.FotografAciklamasi).IsRequired(false);
            builder.Property(k => k.FotografSirasi).IsRequired(false);
            builder.HasOne(k => k.Urunler).WithMany(k => k.Fotograflar).HasForeignKey(k => k.UrunId);
        }
    }
}
