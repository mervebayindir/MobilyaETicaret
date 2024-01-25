using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Repository.Repositories
{
    public class UrunlerRepository : GenericRepository<Urunler>, IUrunlerRepository
    {
        public UrunlerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Urunler> UrunSilAsync(int id)
        {
            var urunSil = await GetByIdAsync(id);
            if (urunSil != null)
            {
                urunSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }
            return urunSil;
        }

        public async Task<Urunler> UrunlerVeKategoriGetir(int urunlerId)
        {
            return await _appDbContext.Urunler.Where(k => k.Id == urunlerId).Include(k => k.Kategoriler).FirstOrDefaultAsync();
        }

        public async Task<List<Urunler>> UrunlerVeKategoriGetir()
        {
            return await _appDbContext.Urunler.Include(k => k.Kategoriler).ToListAsync();
        }
    }
}
