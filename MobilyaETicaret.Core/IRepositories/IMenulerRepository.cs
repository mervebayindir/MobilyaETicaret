using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IMenulerRepository : IGenericRepository<Menuler>
    {
        Task<List<Menuler>> MenulerVeErisimAlanlariAsync();
        Task<Menuler> MenulerVeErisimAlanlariAsync(int id);

        Task<Menuler> AdresSilAsync(int id);

    }
}
