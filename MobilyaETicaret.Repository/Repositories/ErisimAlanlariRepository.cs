using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class ErisimAlanlariRepository : GenericRepository<ErisimAlanlari>, IErisimAlanlariRepository
    {
        public ErisimAlanlariRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<ErisimAlanlari> ErisimAlaniSil(int id)
        {
         var erisimAlaniSil = await GetByIdAsync(id);
            if (erisimAlaniSil != null)
            {
                erisimAlaniSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }
            return erisimAlaniSil;
        }
    }
}
