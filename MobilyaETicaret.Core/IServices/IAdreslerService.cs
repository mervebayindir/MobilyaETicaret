using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
	public interface IAdreslerService : IService<Adresler>
	{
		Task<List<Sp_AdreslerWithMusteriDTO>> AdresVeMusteri();
		Task<object> AdresSilAsync(int id);
		Task<Adresler> AdresEkleAsync(Adresler adresler);
		Task<List<Adresler>> GetAdreslerWithIlcelerAsync(int id);

    }
}
