using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using MobilyaETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class SiparisDetayService : Service<SiparisDetay>, ISiparisDetayService
    {
        private readonly ISiparisDetayRepository _siparisDetayRepository;
        public SiparisDetayService(IUnitOfWork unitOfWork, IGenericRepository<SiparisDetay> genericRepository, ISiparisDetayRepository siparisDetayRepository) : base(unitOfWork, genericRepository)
        {
            _siparisDetayRepository = siparisDetayRepository;
        }


        public Task<List<Sp_SiparisBilgileriDTO>> SiparisBilgileriGetir(int siparisId)
        {
            return _siparisDetayRepository.SiparisBilgileriGetir(siparisId);
        }

        public Task<List<SiparisDetay>> SiparisDetayBilgileriGetirAsync(int siparisId)
        {
            return _siparisDetayRepository.SiparisDetayBilgileriGetirAsync(siparisId);
        }
    }
}
