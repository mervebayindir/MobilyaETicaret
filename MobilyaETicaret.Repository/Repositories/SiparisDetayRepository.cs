using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class SiparisDetayRepository : GenericRepository<SiparisDetay>, ISiparisDetayRepository
    {
        public SiparisDetayRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<List<Sp_SiparisBilgileriDTO>> SiparisBilgileriGetir(int siparisId)
        {
            var siparisBilgileri = await _appDbContext.Sp_SiparisBilgileri(siparisId);
            return siparisBilgileri;
        }

        public async Task<List<SiparisDetay>> SiparisDetayBilgileriGetirAsync(int siparisId)
        {
            var siparisDetaylari = await _appDbContext.SiparisDetay.Include(k => k.Siparisler).Include(k => k.Urunler).ToListAsync();
            return siparisDetaylari;
        }
    }
}
