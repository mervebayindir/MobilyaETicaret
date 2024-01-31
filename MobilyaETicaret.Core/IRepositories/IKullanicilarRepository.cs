using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
	public interface IKullanicilarRepository: IGenericRepository<Kullanicilar>
	{
		Task<List<Kullanicilar>> KullaniciVeYetkiGetirAsync();
		Task<Kullanicilar> KullaniciVeYetkiGetirAsync(int kullanicilarId);
		Task<Kullanicilar> KullaniciSilAsync(int id);
        Task<Kullanicilar> KullaniciGirisAsync(string kullaniciEmail, string kullaniciSifre);
    }
}
