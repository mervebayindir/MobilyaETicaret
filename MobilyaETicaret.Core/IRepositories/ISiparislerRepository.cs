using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface ISiparislerRepository : IGenericRepository<Siparisler>
    {
        Task<Siparisler> SiparisVeMusteriGetirAsync();
        Task<Siparisler> SiparisVeMusteriGetirAsync(int musteri);
        Task<Sp_SiparisBilgileriDTO> SiparisBilgileriGetir(int siparisId);


    }
}
