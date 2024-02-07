using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class YorumlarRepository : GenericRepository<Yorumlar>, IYorumlarRepository
    {
        public YorumlarRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Yorumlar> YorumSilAsync(int id)
        {
            var yorumSil = await GetByIdAsync(id);
            if (yorumSil != null)
            {
                yorumSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return yorumSil;
        }

        public Task<List<Yorumlar>> YorumVeUrunAsync()
        {
            return _appDbContext.Yorumlar.Include(k => k.Urunler).Include(k => k.Kullanicilar).ToListAsync();
        }

        public Task<List<Yorumlar>> YorumVeUrunAsync(int urunId)
        {
            return _appDbContext.Yorumlar.Where(k => k.UrunId == urunId).Include(k => k.Urunler).Include(k => k.Kullanicilar).ToListAsync();
        }
    }
}
