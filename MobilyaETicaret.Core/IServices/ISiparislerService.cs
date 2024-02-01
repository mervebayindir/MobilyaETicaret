using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface ISiparislerService : IService<Siparisler>
    {
        Task<List<Siparisler>> SiparisVeMusteriGetirAsync();
        Task<List<Siparisler>> SiparisVeMusteriGetirAsync(int musteriId);
        Task<List<Sp_SiparisBilgileriDTO>> SiparisBilgileriGetir(int siparisId);
        Task<Siparisler> SiparisSilAsync(int id);
    }
}
