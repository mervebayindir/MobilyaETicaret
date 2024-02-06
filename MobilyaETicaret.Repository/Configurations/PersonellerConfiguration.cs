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
    public class PersonellerConfiguration : IEntityTypeConfiguration<Personeller>
    {
        public void Configure(EntityTypeBuilder<Personeller> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.PersonelAdi).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PersonelSoyadi).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PersonelMaasi).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.MaasOdemeTarihi).IsRequired();
            builder.Property(p => p.CalistigiFirma).IsRequired();
            builder.Property(p => p.PersonelHakkinda).HasMaxLength(200).IsRequired();
            builder.Property(p => p.YasadigiSehir).IsRequired();
            builder.HasOne(k => k.Kullanicilar).WithMany(k => k.Personeller).HasForeignKey(k => k.KullaniciId);
        }
    }
}
