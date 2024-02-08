using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
	public interface IFotograflarRepository : IGenericRepository<Fotograflar>
	{
		Task<List<Fotograflar>> FotografVeUrunGetir();

		Task<Fotograflar> FotografVeUrunGetir(int fotografId);

		Task<Fotograflar> FotografSilAsync(int id);
        Task<Fotograflar> FotografPasifEtAsync(int id);
		Task<List<Fotograflar>> FotograflarByUrunIdAsync(int urunId);


	}
}
