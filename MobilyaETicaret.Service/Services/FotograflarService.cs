using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
	public class FotograflarService : Service<Fotograflar>, IFotografService
	{
		private readonly IFotograflarRepository _fotograflarRepository;
		private readonly IMapper _mapper;
		public FotograflarService(IUnitOfWork unitOfWork, IGenericRepository<Fotograflar> genericRepository, IFotograflarRepository fotograflarRepository, IMapper mapper) : base(unitOfWork, genericRepository)
		{
			_fotograflarRepository = fotograflarRepository;
			_mapper = mapper;
		}

		public async Task<int> FotografEkleAsync(string fotografYolu, string adi, string fotografAciklamasi, int fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi)
		{
			try
			{
				Fotograflar fotograf = new Fotograflar();
				fotograf.FotografYolu = fotografYolu;
				fotograf.FotografAdi = adi;
				fotograf.FotografAciklamasi = fotografAciklamasi;
				fotograf.FotografSirasi = fotografSirasi;
				fotograf.UrunId = urunId;
				fotograf.AktifMi = aktifMi;
				fotograf.EklenmeTarih = eklemeTarihi;

				await AddAsync(fotograf);

                return fotograf.Id;
            }
			catch (Exception)
			{
                return -1;
            }
		}		

		public async Task<object> FotografSilAsync(int id)
		{
			var adresGetir = await _fotograflarRepository.GetByIdAsync(id);
			if (adresGetir != null)
			{
				return await _fotograflarRepository.FotografSilAsync(adresGetir.Id);
			}
			return null;
		}

		public async Task<List<FotograflarVeUrunlerDTO>> FotografVeUrunGetir()
		{
			var fotografWithUrun = await _fotograflarRepository.FotografVeUrunGetir();
			var fotografUrunDTO = _mapper.Map<List<FotograflarVeUrunlerDTO>>(fotografWithUrun);

			return fotografUrunDTO;
		}

		public async Task<FotograflarVeUrunlerDTO> FotografVeUrunGetir(int fotografId)
		{
			var fotografWithUrun = await _fotograflarRepository.FotografVeUrunGetir(fotografId);
			var fotografUrunDTO = _mapper.Map<FotograflarVeUrunlerDTO>(fotografWithUrun);

			return fotografUrunDTO;
		}

		public async Task<int> UrunFotografSayisiGetir(int urunId)
		{
			return await _fotograflarRepository.GetAllQuery(f => f.UrunId == urunId).CountAsync();
		}
	}
}
