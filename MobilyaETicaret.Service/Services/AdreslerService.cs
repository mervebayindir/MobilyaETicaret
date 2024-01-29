using AutoMapper;
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
#nullable disable

namespace MobilyaETicaret.Service.Services
{
	public class AdreslerService : Service<Adresler>, IAdreslerService
	{
		private readonly IAdreslerRepository _adreslerRepository;
		private readonly IMapper _mapper;
        public AdreslerService(IUnitOfWork unitOfWork, IGenericRepository<Adresler> genericRepository, IAdreslerRepository adreslerRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _adreslerRepository = adreslerRepository;
            _mapper = mapper;
        }

        public async Task<Adresler> AdresEkleAsync(Adresler adresler)
        {
			adresler.AktifMi = true;
			adresler.EklenmeTarih = DateTime.Now;
			if (adresler != null)
			{
				await _adreslerRepository.AddAsync(adresler);
			}
			return null;
        }

        public async Task<object> AdresSilAsync(int id)
		{
			var adresGetir = await _adreslerRepository.GetByIdAsync(id);
			if (adresGetir != null)
			{
				return await _adreslerRepository.AdresSilAsync(adresGetir.Id);
			}
			return null;
		}

		public async Task<List<Sp_AdreslerWithMusteriDTO>> AdresVeMusteri()
		{
			var adresVeMusteri = await _adreslerRepository.AdresVeMusteri();
			return adresVeMusteri;
		}

        public Task<List<Adresler>> AdreslerVeIlcelerAsync(int id)
        {
			var illerveIlceler = _adreslerRepository.AdreslerVeIlcelerAsync(id);
			return illerveIlceler;
        }
		
	}
}
