using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
	public interface IFotografService : IService<Fotograflar>
	{
		Task<int> FotografEkleAsync(string fotografYolu, string adi, string fotografAciklamasi, int fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi);

		Task<List<FotograflarVeUrunlerDTO>> FotografVeUrunGetir();

		Task<FotograflarVeUrunlerDTO> FotografVeUrunGetir(int fotografId);

		Task<int> UrunFotografSayisiGetir(int urunId);

		Task<object> FotografSilAsync(int id);
		Task<object> FotografPasifEtAsync(int id);

    }
}
