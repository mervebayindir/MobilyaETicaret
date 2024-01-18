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
    public class KategorilerConfiguration : IEntityTypeConfiguration<Kategoriler>
    {
        public void Configure(EntityTypeBuilder<Kategoriler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Aciklama).IsRequired(false);
            builder.Property(k => k.KategoriAdi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.FotografId).IsRequired();
            builder.HasOne(k => k.Fotograflar).WithOne(k => k.Kategoriler).HasForeignKey<Kategoriler>(k => k.FotografId);

        }
    }
}
