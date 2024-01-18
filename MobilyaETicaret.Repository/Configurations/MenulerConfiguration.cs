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
    public class MenulerConfiguration : IEntityTypeConfiguration<Menuler>
    {
        public void Configure(EntityTypeBuilder<Menuler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.MenuAdi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Aciklama).IsRequired(false);
            builder.HasOne(k => k.UstMenu).WithMany(k => k.AltMenu).HasForeignKey(k => k.UstMenuId);
        }
    }
}
