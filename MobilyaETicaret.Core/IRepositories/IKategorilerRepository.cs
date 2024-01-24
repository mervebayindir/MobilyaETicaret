using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IKategorilerRepository : IGenericRepository<Kategoriler>
    {
        Task<Kategoriler> KategoriSilAsync(int id);
    }
}
