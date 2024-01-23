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
    public class AdreslerRepository : GenericRepository<Adresler>, IAdreslerRepository
    {
        public AdreslerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }


        public async Task<Adresler> AdresSilAsync(int id)
        {
            var adresSil = await GetByIdAsync(id);
            if (adresSil != null)
            {
                adresSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return adresSil;
        }

        public async Task<List<Sp_AdreslerWithMusteriDTO>> AdresVeMusteri()
        {
            var adresListe = await _appDbContext.Sp_AdresMusteri();
            return adresListe;
        }

        public async Task<List<Adresler>> GetAdreslerWithIlcelerAsync(int ilceKodu)
        {
            return await _appDbContext.Adresler.Include(x => x.Ilce).ThenInclude(ilce => ilce.Iller).Where(x => x.IlceKodu == ilceKodu).ToListAsync();
        }

        public Task<List<Adresler>> GetAdreslerWithIlcelerAsync()
        {
            return _appDbContext.Adresler.Include(x => x.Ilce).ThenInclude(x => x.Iller).ToListAsync();
        }

        public Task<Adresler> GetAdreslerWithMusteriAsync(int musteriId)
        {
            return _appDbContext.Adresler.Include(x => x.Musteriler).Where(x => x.MusteriId == musteriId).FirstOrDefaultAsync();
        }



    }
}
