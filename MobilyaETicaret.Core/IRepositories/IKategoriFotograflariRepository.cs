using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IKategoriFotograflariRepository : IGenericRepository<KategoriFotograflari>
    {
        Task<KategoriFotograflari> KategoriveFotografGetirAsync(int kategoriId);
    }
}
