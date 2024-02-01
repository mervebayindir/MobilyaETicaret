using AutoMapper;
using MobilyaETicaret.Core.DTO;
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
    public class UrunlerService : Service<Urunler>, IUrunlerService
    {
        private readonly IUrunlerRepository _urunlerRepository;
        private readonly IMapper _mapper;
        public UrunlerService(IUnitOfWork unitOfWork, IGenericRepository<Urunler> genericRepository, IUrunlerRepository urunlerRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _urunlerRepository = urunlerRepository;
            _mapper = mapper;
        }

        public async Task<List<UrunlerveKategoriDTO>> UrunlerVeKategoriGetir()
        {
            var urunVeKategoriList = await _urunlerRepository.UrunlerVeKategoriGetir();
            var urunVeKategoriDTO = _mapper.Map<List<UrunlerveKategoriDTO>>(urunVeKategoriList);
            return urunVeKategoriDTO;
        }

        public async Task<UrunlerveKategoriDTO> UrunlerVeKategoriGetir(int urunlerId)
        {
            var urunVeKategori = await _urunlerRepository.UrunlerVeKategoriGetir(urunlerId);
            var urunVeKategoriDTO = _mapper.Map<UrunlerveKategoriDTO>(urunVeKategori);
            return urunVeKategoriDTO;
        }

        public async Task<object> UrunSilAsync(int id)
        {
            var urunGetir = await _urunlerRepository.GetByIdAsync(id);
            if (urunGetir != null)
            {
                return await _urunlerRepository.UrunSilAsync(urunGetir.Id);
            }
            return null;
        }

        public async Task<UrunVeFotografDTO> UrunveFotografURLGetir(int urunId)
        {
			var urunVeFotograf = await _urunlerRepository.UrunVeFotografGetir(urunId);

			if (urunVeFotograf == null || !urunVeFotograf.Any())
			{
				return null;
			}
			var urunVeFotografDTO = urunVeFotograf.Select(u => new UrunVeFotografDTO
			{
				UrunId = u.Id,
				UrunAdi = u.UrunAdi,
				UrunFiyat = u.UrunFiyat,
				UrunAdet = 0, 
				FotografUrl = u.Fotograflar.FirstOrDefault()?.FotografYolu 
			}).FirstOrDefault(); 

			return urunVeFotografDTO;

		}
    }
}
