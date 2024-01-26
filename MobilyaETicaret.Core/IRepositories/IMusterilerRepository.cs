using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IMusterilerRepository : IGenericRepository<Musteriler>
    {
        Task<List<SP_MusteriBilgilerDTO>> MusterilerVeSiparisler();
        Task<Musteriler> MusterilerVeSiparisler(int musteriId);
        Task<Musteriler> MusteriSilAsync(int id);
    }
}
