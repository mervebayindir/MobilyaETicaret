using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
	public interface IAdreslerRepository : IGenericRepository<Adresler>
	{
		Task<List<Adresler>> GetAdreslerWithIlcelerAsync(int ılceKodu);
		Task<List<Adresler>> GetAdreslerWithIlcelerAsync();
		Task<List<Sp_AdreslerWithMusteriDTO>> AdresVeMusteri();
		Task<Adresler> GetAdreslerWithMusteriAsync(int musteriId);
		Task<Adresler> AdresSilAsync(int id);

	}
}
