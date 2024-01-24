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
    public class KategoriFotograflariConfiguration : IEntityTypeConfiguration<KategoriFotograflari>
    {
        public void Configure(EntityTypeBuilder<KategoriFotograflari> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.FotografYolu).IsRequired();
            builder.Property(k => k.FotografAdi).IsRequired(false);
            builder.Property(k => k.FotografAciklamasi).IsRequired(false);
            builder.HasOne(k => k.Kategoriler).WithOne(k => k.KategoriFotograflari).HasForeignKey<KategoriFotograflari>(k => k.KategoriId);
        }
    }
}
