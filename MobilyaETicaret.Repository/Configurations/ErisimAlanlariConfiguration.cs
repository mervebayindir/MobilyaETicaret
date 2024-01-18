using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Configurations
{
    public class ErisimAlanlariConfiguration : IEntityTypeConfiguration<ErisimAlanlari>
    {
        public void Configure(EntityTypeBuilder<ErisimAlanlari> builder)
        {
            //ErisimAlanlari=> Erişim Sayfaları

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.AktifMi).IsRequired();
            builder.Property(e => e.ControllerAdi).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ViewAdi).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Aciklama).IsRequired(false);
            builder.HasOne(k => k.Menuler).WithOne(k => k.ErisimAlanlari).HasForeignKey<Menuler>(k => k.ErisimAlanlariId);
        }
    }
}
