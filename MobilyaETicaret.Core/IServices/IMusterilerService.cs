using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IMusterilerService : IService<Musteriler>
    {
        Task<Musteriler> MusterilerVeSiparisler(int musteriId);
        Task<Musteriler> MusteriSilAsync(int id);
    }
}
