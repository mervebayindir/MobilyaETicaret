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
    public class YetkilerService : Service<Yetkiler>, IYetkilerService
    {
        private readonly IYetkilerRepository _yetkilerRepository;
        public YetkilerService(IUnitOfWork unitOfWork, IGenericRepository<Yetkiler> genericRepository, IYetkilerRepository yetkilerRepository) : base(unitOfWork, genericRepository)
        {
            _yetkilerRepository = yetkilerRepository;
        }

        public async Task<object> YetkiSilAsync(int id)
        {
            var yetkiGetir = await _yetkilerRepository.GetByIdAsync(id);
            if (yetkiGetir != null)
            {
                return await _yetkilerRepository.YetkiSilAsync(yetkiGetir.Id);
            }
            return null;
        }
    }
}
