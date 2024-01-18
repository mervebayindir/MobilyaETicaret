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
    public class IlcelerConfiguration : IEntityTypeConfiguration<Ilceler>
    {
        public void Configure(EntityTypeBuilder<Ilceler> builder)
        {
            builder.HasKey(k => k.IlceKodu);
            builder.Property(k => k.IlceKodu).IsRequired();
            builder.Property(k => k.IlceAdi).IsRequired().HasMaxLength(128);
            builder.HasOne(k => k.Iller).WithMany(k => k.Ilceler).HasForeignKey(k => k.IlKodu);
        }
    }
}
