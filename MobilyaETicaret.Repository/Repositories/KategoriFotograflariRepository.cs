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
    public class KategoriFotograflariRepository : GenericRepository<KategoriFotograflari>, IKategoriFotograflariRepository
    {
        public KategoriFotograflariRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<string> KategoriveFotografGetir(int kategoriId)
        {
            var fotografYolu = await _appDbContext.KategoriFotograflari.Where(kf => kf.KategoriId == kategoriId).Select(kf => kf.FotografYolu).FirstOrDefaultAsync();
            return fotografYolu;
        }
    }
}
