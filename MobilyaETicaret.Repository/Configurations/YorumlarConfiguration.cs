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
    public class YorumlarConfiguration : IEntityTypeConfiguration<Yorumlar>
    {
        public void Configure(EntityTypeBuilder<Yorumlar> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Yorum).IsRequired().HasMaxLength(250);
            builder.Property(k => k.EklenmeTarih).IsRequired(true);
        }
    }
}
