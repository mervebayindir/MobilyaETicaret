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
    public class YorumlarService : Service<Yorumlar>, IYorumlarService
    {
        private readonly IYorumlarRepository _yorumlarRepository;
        public YorumlarService(IUnitOfWork unitOfWork, IGenericRepository<Yorumlar> genericRepository, IYorumlarRepository yorumlarRepository) : base(unitOfWork, genericRepository)
        {
            _yorumlarRepository = yorumlarRepository;
        }

        public async Task<object> YorumSilAsync(int id)
        {
            var yorumGetir = await _yorumlarRepository.GetByIdAsync(id);
            if (yorumGetir != null)
            {
                return await _yorumlarRepository.YorumSilAsync(yorumGetir.Id);
            }
            return null;
        }

        public async Task<List<Yorumlar>> YorumVeUrunAsync()
        {
            return await _yorumlarRepository.YorumVeUrunAsync();
        }

        public async Task<List<Yorumlar>> YorumVeUrunAsync(int urunId)
        {
            return await _yorumlarRepository.YorumVeUrunAsync(urunId);
        }
    }
}
