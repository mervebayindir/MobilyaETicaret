using AutoMapper;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class MusterilerService : Service<Musteriler>, IMusterilerService
    {
        private readonly IMusterilerRepository _musterilerRepository;
        private readonly IMapper _mapper;
        public MusterilerService(IUnitOfWork unitOfWork, IGenericRepository<Musteriler> genericRepository, IMapper mapper, IMusterilerRepository musterilerRepository) : base(unitOfWork, genericRepository)
        {
            _mapper = mapper;
            _musterilerRepository = musterilerRepository;
        }

        public async Task<Musteriler> MusterilerVeSiparisler(int musteriId)
        {
            return await _musterilerRepository.MusterilerVeSiparisler(musteriId);
        }

        public async Task<List<SP_MusteriBilgilerDTO>> MusterilerVeSiparisler()
        {
            return await _musterilerRepository.MusterilerVeSiparisler();
        }

        public async Task<Musteriler> MusteriSilAsync(int id)
        {
            return await _musterilerRepository.MusteriSilAsync(id);
        }
    }
}
