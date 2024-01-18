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
    public class YetkilerConfiguration : IEntityTypeConfiguration<Yetkiler>
    {
        public void Configure(EntityTypeBuilder<Yetkiler> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id).UseIdentityColumn();
            builder.Property(y => y.AktifMi).IsRequired();
            builder.Property(y => y.YetkiAdi).IsRequired().HasMaxLength(100);
        }
    }
}
