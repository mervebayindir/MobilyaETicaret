using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Kategoriler> Kategoriler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DbSet<Iller> Iller { get; set; }
        public DbSet<Ilceler> Ilceler { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<ErisimAlanlari> ErisimAlanlari { get; set; }
        public DbSet<Menuler> Menular { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Fotograflar> Fotograflar { get; set; }
        public DbSet<Personeller> Personeller { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<Siparisler> Siparisler { get; set; }
        public DbSet<YetkiErisim> YetkiErisim { get; set; }
        public DbSet<Yetkiler> Yetkiler { get; set; }
        public DbSet<Yorumlar> Yorumlar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
