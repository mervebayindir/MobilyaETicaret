using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class YetkilerRepository : GenericRepository<Yetkiler>
    {
        public YetkilerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }
    }
}
