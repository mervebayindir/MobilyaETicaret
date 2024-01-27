using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class ErisimAlanlariService : Service<ErisimAlanlari>, IErisimAlanlariService
    {
        private readonly IErisimAlanlariRepository _erisimAlanlariRepository;
        public ErisimAlanlariService(IUnitOfWork unitOfWork, IGenericRepository<ErisimAlanlari> genericRepository, IErisimAlanlariRepository erisimAlanlariRepository) : base(unitOfWork, genericRepository)
        {
            _erisimAlanlariRepository = erisimAlanlariRepository;
        }

        public async Task<object> ErisimAlaniSilAsync(int id)
        {
            var erisimAlaniGetir = await _erisimAlanlariRepository.GetByIdAsync(id);
            if (erisimAlaniGetir != null)
            {
                return await _erisimAlanlariRepository.ErisimAlaniSil(erisimAlaniGetir.Id);
            }
            return null;
        }
    }
}
