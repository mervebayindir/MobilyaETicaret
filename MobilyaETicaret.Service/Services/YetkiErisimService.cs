using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class YetkiErisimService : Service<YetkiErisim>, IYetkiErisimService
    {
        public YetkiErisimService(IUnitOfWork unitOfWork, IGenericRepository<YetkiErisim> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
