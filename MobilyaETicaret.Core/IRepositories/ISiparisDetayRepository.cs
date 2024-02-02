using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface ISiparisDetayRepository : IGenericRepository<SiparisDetay>
    {
        Task<List<Sp_SiparisBilgileriDTO>> SiparisBilgileriGetir(int siparisId);

        Task<List<SiparisDetay>> SiparisDetayBilgileriGetirAsync(int siparisId);
    }
}
