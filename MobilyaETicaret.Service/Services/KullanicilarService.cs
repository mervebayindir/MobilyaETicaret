using AutoMapper;
using MobilyaETicaret.Core.DTO;
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
	public class KullanicilarService : Service<Kullanicilar>, IKullanicilarService
	{
		private readonly IKullanicilarRepository _kullanicilarRepository;
		private readonly IMapper _mapper;
		public KullanicilarService(IUnitOfWork unitOfWork, IGenericRepository<Kullanicilar> genericRepository, IKullanicilarRepository kullanicilarRepository, IMapper mapper) : base(unitOfWork, genericRepository)
		{
			_kullanicilarRepository = kullanicilarRepository;
			_mapper = mapper;
		}

		public async Task<List<KullanicilarVeYetkilerDTO>> KullaniciVeYetkiGetirAsync()
		{
			var kullaniciYetkiList = await _kullanicilarRepository.KullaniciVeYetkiGetirAsync();
			var kullaniciVeYetkiDTO = _mapper.Map<List<KullanicilarVeYetkilerDTO>>(kullaniciYetkiList);
			return kullaniciVeYetkiDTO;
		}

		public async Task<KullanicilarVeYetkilerDTO> KullaniciVeYetkiGetirAsync(int kullanicilarId)
		{
			var kullaniciYetkiList = await _kullanicilarRepository.KullaniciVeYetkiGetirAsync(kullanicilarId);
			var kullaniciVeYetkiDTO = _mapper.Map<KullanicilarVeYetkilerDTO>(kullaniciYetkiList);
			return kullaniciVeYetkiDTO;
		}

        public async Task<Kullanicilar> Giris(string kullaniciEmail, string sifre)
        {
			var kullanici = await _kullanicilarRepository.KullaniciGirisAsync(kullaniciEmail, sifre);
            return kullanici;
        }

        public async Task<int> KullaniciEkleAsync(string adi, string soyadi, string kullaniciEmail, string sifre, bool personelMi, int yetkiId, bool aktifMi, DateTime eklenmeTarihi)
        {
			try
			{
				Kullanicilar kullanicilar = new Kullanicilar();
				kullanicilar.Adi = adi;
				kullanicilar.Soyadi = soyadi;
				kullanicilar.KullaniciEmail = kullaniciEmail;
				kullanicilar.KullaniciSifre = sifre;
				kullanicilar.PersonelMi = personelMi;
				kullanicilar.YetkiId = yetkiId;
				kullanicilar.AktifMi = aktifMi;
				kullanicilar.EklenmeTarih = eklenmeTarihi;
				await AddAsync(kullanicilar);
				return kullanicilar.Id;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<int> KullanicigGuncellesync(string adi, string soyadi, string kullaniciEmail, string sifre, bool personelMi, int yetkiId, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi)
        {
            try
            {
                Kullanicilar kullanicilar = new Kullanicilar();
                kullanicilar.Adi = adi;
                kullanicilar.Soyadi = soyadi;
                kullanicilar.KullaniciEmail = kullaniciEmail;
                kullanicilar.KullaniciSifre = sifre;
                kullanicilar.PersonelMi = personelMi;
                kullanicilar.YetkiId = yetkiId;
                kullanicilar.AktifMi = aktifMi;
                kullanicilar.EklenmeTarih = eklenmeTarihi;
                kullanicilar.GuncellenmeTarih = guncellenmeTarihi;
                await AddAsync(kullanicilar);
                return kullanicilar.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

		public async Task<Kullanicilar> KullaniciSilAsync(int id)
		{
			var kullaniciGetir = await _kullanicilarRepository.GetByIdAsync(id);
			if (kullaniciGetir != null)
			{
				return await _kullanicilarRepository.KullaniciSilAsync(kullaniciGetir.Id);
			}
			return null;
		}
	}
}
