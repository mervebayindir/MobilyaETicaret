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
    public class OdemelerConfiguration : IEntityTypeConfiguration<Odemeler>
    {
        public void Configure(EntityTypeBuilder<Odemeler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.OdemeTipi).IsRequired();
            builder.Property(k => k.KartId).IsRequired(false);
            builder.HasOne(k=>k.KrediKartBilgileri).WithMany(k=>k.Odemeler).HasForeignKey(k=>k.KartId);
        }
    }
}
