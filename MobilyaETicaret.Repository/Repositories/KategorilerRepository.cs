using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class KategorilerRepository : GenericRepository<Kategoriler>, IKategorilerRepository
    {
        public KategorilerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Kategoriler> KategoriSilAsync(int id)
        {
            var kategoriSil = await GetByIdAsync(id);
            if (kategoriSil != null)
            {
                kategoriSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }
            return kategoriSil;
        }

    }
}
