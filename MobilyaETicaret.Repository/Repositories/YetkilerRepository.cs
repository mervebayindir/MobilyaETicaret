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
    }
}
