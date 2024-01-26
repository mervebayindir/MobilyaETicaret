using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Repository.Repositories
{
    public class MusterilerRepository : GenericRepository<Musteriler>, IMusterilerRepository
    {
        public MusterilerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public Task<Musteriler> MusterilerVeSiparisler(int musteriId)
        {
            return _appDbContext.Musteriler.Include(k => k.Siparisler).Where(k => k.Id == musteriId).FirstOrDefaultAsync();
        }

        public async Task<List<SP_MusteriBilgilerDTO>> MusterilerVeSiparisler()
        {
            var musteriBilgileri = await _appDbContext.Sp_MusteriBilgileri();
            return musteriBilgileri;
        }

        public async Task<Musteriler> MusteriSilAsync(int id)
        {
            var musteriSil = await GetByIdAsync(id);
            if (musteriSil != null)
            {
                musteriSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return musteriSil;
        }
    }
}
