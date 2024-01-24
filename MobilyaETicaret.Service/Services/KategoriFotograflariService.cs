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
    public class KategoriFotograflariService : Service<KategoriFotograflari>, IKategoriFotograflariService
    {
        private readonly IKategoriFotograflariRepository _kategoriFotograflariRepository;
        public KategoriFotograflariService(IUnitOfWork unitOfWork, IGenericRepository<KategoriFotograflari> genericRepository, IKategoriFotograflariRepository kategoriFotograflariRepository) : base(unitOfWork, genericRepository)
        {
            _kategoriFotograflariRepository = kategoriFotograflariRepository;
        }

        public async Task<string> KategoriveFotografGetir(int kategoriId)
        {
            return await _kategoriFotograflariRepository.KategoriveFotografGetir(kategoriId);
        }
    }
}
