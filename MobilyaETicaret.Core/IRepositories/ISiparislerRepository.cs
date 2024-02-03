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
        Task<List<Siparisler>> SiparisDetaylarGetirAsync();
        Task<List<Siparisler>> SiparisDetaylarGetirAsync(int siparisId);
        Task<List<Siparisler>> SiparisVeMusteriGetirAsync();
        Task<List<Siparisler>> SiparisVeMusteriGetirAsync(int musteriId);
        Task<Siparisler> SiparisSilAsync(int id);

    }
}
