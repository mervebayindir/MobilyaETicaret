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
	public class FotograflarService : Service<Fotograflar>, IFotografService
	{
		private readonly IFotograflarRepository _fotograflarRepository;
		private readonly IMapper _mapper;
		public FotograflarService(IUnitOfWork unitOfWork, IGenericRepository<Fotograflar> genericRepository, IFotograflarRepository fotograflarRepository, IMapper mapper) : base(unitOfWork, genericRepository)
		{
			_fotograflarRepository = fotograflarRepository;
			_mapper = mapper;
		}

		public async Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
		{
			try
			{
				Fotograflar fotograf = new Fotograflar();//Garbage Collector oluşur
				fotograf.FotografYolu = fotografYolu;
				fotograf.FotografAciklamasi = fotografAciklamasi;
				fotograf.FotografSirasi = fotografSirasi;
				fotograf.UrunId = urunId;
				fotograf.AktifMi = aktifMi;
				fotograf.EklenmeTarih = eklemeTarihi;
				fotograf.GuncellenmeTarih = guncellemeTarihi;

				await AddAsync(fotograf);

				return "RESİM EKLEME BAŞARILI";
			}
			catch (Exception ex)
			{
				return "Ekleme esnasında hata oluştu." + ex;
			}
		}

		public async Task<string> FotografGuncelleAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
		{
			var fotografBul = await GetByIdAsync(fotografId);

			try
			{
				fotografBul.FotografYolu = fotografYolu;
				fotografBul.FotografAciklamasi = fotografAciklamasi;
				fotografBul.FotografSirasi = fotografSirasi;
				fotografBul.UrunId = urunId;
				fotografBul.AktifMi = aktifMi;
				fotografBul.EklenmeTarih = eklemeTarihi;
				fotografBul.GuncellenmeTarih = guncellemeTarihi;

				return "Güncelleme başarılı.";
			}
			catch (Exception)
			{
				return "Güncelleme esnasında hata oluştu.";
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
	}
}
