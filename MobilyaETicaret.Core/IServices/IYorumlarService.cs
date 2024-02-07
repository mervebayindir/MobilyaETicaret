using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IYorumlarService : IService<Yorumlar>
    {
        Task<List<Yorumlar>> YorumVeUrunAsync();
        Task<List<Yorumlar>> YorumVeUrunAsync(int urunId);
        Task<object> YorumSilAsync(int id);
    }
}
