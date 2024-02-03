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
    public class SiparislerConfiguration : IEntityTypeConfiguration<Siparisler>
    {
        public void Configure(EntityTypeBuilder<Siparisler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.EklenmeTarih).IsRequired();
            builder.Property(k => k.ToplamUrunAdet).IsRequired();
            builder.Property(k => k.ToplamFiyat).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(k => k.MusteriId).IsRequired();
            builder.Property(k => k.AdresId).IsRequired(true);
            builder.HasMany(k => k.SiparisDetay).WithOne(k => k.Siparisler).HasForeignKey(k => k.SiparisId);
            builder.HasOne(k => k.Odemeler).WithOne(k => k.Siparisler).HasForeignKey<Siparisler>(k => k.OdemeId);
            builder.HasOne(k => k.Adresler).WithOne(k => k.Siparisler).HasForeignKey<Siparisler>(k => k.AdresId);

        }
    }
}
