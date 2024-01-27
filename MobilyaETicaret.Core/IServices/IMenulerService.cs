using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IMenulerService : IService<Menuler>
    {
        Task<IEnumerable<MenulerVeErisimAlaniDTO>> MenulerVeErisimAlanlariAsync();
        Task<MenulerVeErisimAlaniDTO> MenulerVeErisimAlanlariAsync(int id);
        Task<Menuler> MenuSilAsync(int id);
        Task<bool> ErisimAlaniVarmi(int? erisimAlanlariId, int? haricMenuId = null);
    }
}
