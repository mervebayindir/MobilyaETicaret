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
    public class UrunlerConfiguration : IEntityTypeConfiguration<Urunler>
    {
        public void Configure(EntityTypeBuilder<Urunler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.UrunAdi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Aciklama).IsRequired(false);
            builder.Property(k => k.UrunFiyat).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.HasOne(k => k.Kategoriler).WithMany(k => k.Urunler).HasForeignKey(k => k.KategoriId);
            builder.HasMany(k => k.SiparisDetay).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
            builder.HasMany(k => k.Yorumlar).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
            builder.HasMany(k => k.Fotograflar).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
        }
    }
}
