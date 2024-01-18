using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Configurations
{
    public class KrediKartBilgileriConfiguration : IEntityTypeConfiguration<KrediKartBilgileri>
    {
        public void Configure(EntityTypeBuilder<KrediKartBilgileri> builder)
        {
            builder.HasKey(k => k.KartId);
            builder.Property(k => k.KartId).UseIdentityColumn();
            builder.Property(k => k.CVC).IsRequired();
            builder.Property(k => k.KartSahibiAdiSoyadi).IsRequired();
            builder.Property(k => k.SonKullanmaTarihi).IsRequired();
        }
    }
}
