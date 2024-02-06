using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class YetkilerRepository : GenericRepository<Yetkiler>, IYetkilerRepository
    {
        public YetkilerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Yetkiler> YetkiSilAsync(int id)
        {
            var yetkiSil = await GetByIdAsync(id);
            if (yetkiSil != null)
            {
                yetkiSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }
            return yetkiSil;
        }
    }
}
