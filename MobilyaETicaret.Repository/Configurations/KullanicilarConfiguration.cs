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
    public class KullanicilarConfiguration : IEntityTypeConfiguration<Kullanicilar>
    {
        public void Configure(EntityTypeBuilder<Kullanicilar> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Adi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Soyadi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.KullaniciResim).IsRequired(false);
            builder.Property(k => k.KullaniciEmail).IsRequired(false);
            builder.Property(k => k.KullaniciSifre).IsRequired(false);
            builder.Property(k => k.PersonelMi).IsRequired();
            builder.HasOne(k => k.Yetkiler).WithMany(k => k.Kullanicilar).HasForeignKey(k => k.YetkiId);
            builder.HasMany(k => k.Yorumlar).WithOne(k => k.Kullanicilar).HasForeignKey(k => k.KullaniciId);
            builder.HasMany(k => k.Siparisler).WithOne(k => k.Kullanicilar).HasForeignKey(k => k.KullaniciId);
        }
    }
}
