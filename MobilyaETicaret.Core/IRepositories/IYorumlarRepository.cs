using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IYorumlarRepository : IGenericRepository<Yorumlar>
    {
        Task<List<Yorumlar>> YorumVeUrunAsync();
        Task<List<Yorumlar>> YorumVeUrunAsync(int urunId);
        Task<Yorumlar> YorumSilAsync(int id);
    }
}
