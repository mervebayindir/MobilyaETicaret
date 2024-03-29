﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
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
        public DbSet<Odemeler> Odemeler { get; set; }
        public DbSet<KrediKartBilgileri> KrediKartBilgileri { get; set; }
        public DbSet<KategoriFotograflari> KategoriFotograflari { get; set; }
        public DbSet<Sp_AdreslerWithMusteriDTO> AdresMusteri { get; set; }
        public DbSet<SP_MusteriBilgilerDTO> MusteriBilgileri { get; set; }
        public DbSet<SP_KullaniciBilgileriDTO> KullaniciBilgileri { get; set; }
        public DbSet<Sp_SiparisBilgileriDTO> SiparisBilgileri { get; set; }


        public async Task<List<Sp_AdreslerWithMusteriDTO>> Sp_AdresMusteri()
		{
			var result = await AdresMusteri.FromSqlRaw("EXEC Sp_GetMusteriAdresBilgileri").ToListAsync();
			return result;
		}

        public async Task<List<SP_MusteriBilgilerDTO>> Sp_MusteriBilgileri()
        {
            var result = await MusteriBilgileri.FromSqlRaw("EXEC Sp_MusteriBilgileri").ToListAsync();
            return result;
        }

        public async Task<List<SP_KullaniciBilgileriDTO>> Sp_KullaniciBilgileri()
        {
            var result = await KullaniciBilgileri.FromSqlRaw("EXEC SP_KullaniciBilgileri").ToListAsync();
            return result;
        }

        public async Task<List<Sp_SiparisBilgileriDTO>> Sp_SiparisBilgileri(int siparisId)
        {
            var result = await SiparisBilgileri.FromSqlRaw("EXEC Sp_SiparisBilgileri @SiparisId", new SqlParameter("@SiparisId", siparisId)).ToListAsync();
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sp_AdreslerWithMusteriDTO>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_MusteriBilgilerDTO>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_KullaniciBilgileriDTO>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<Sp_SiparisBilgileriDTO>(entity =>
            {
                entity.HasNoKey();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MobilyaETicaretDB;Integrated Security=True;Encrypt=False");
            }
        }
    }
}
