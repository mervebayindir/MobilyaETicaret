using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
	public interface IKullanicilarService : IService<Kullanicilar>
	{
        Task<int> KullaniciEkleAsync(string adi, string soyadi, string kullaniciEmail, string sifre, bool personelMi, int yetkiId, bool aktifMi, DateTime eklenmeTarihi);
        Task<int> KullanicigGuncellesync(string adi, string soyadi, string kullaniciEmail, string sifre, bool personelMi, int yetkiId, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi);
        Task<List<KullanicilarVeYetkilerDTO>> KullaniciVeYetkiGetirAsync();
		Task<KullanicilarVeYetkilerDTO> KullaniciVeYetkiGetirAsync(int kullanicilarId);
        Task<Kullanicilar> Giris(string kullaniciEmail, string sifre);
        Task<List<SP_KullaniciBilgileriDTO>> KullaniciBilgileri();
        Task<SP_KullaniciBilgileriDTO> KullaniciBilgileri(int kullaniciId);
    }
}
