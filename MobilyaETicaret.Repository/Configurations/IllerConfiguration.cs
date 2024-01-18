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
    public class IllerConfiguration : IEntityTypeConfiguration<Iller>
    {
        public void Configure(EntityTypeBuilder<Iller> builder)
        {
            builder.HasKey(k => k.IlKodu);
            builder.Property(k => k.IlAdi).IsRequired().HasMaxLength(128);
        }
    }
}
