using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IUrunlerRepository : IGenericRepository<Urunler>
    {
        Task<List<Urunler>> UrunlerVeKategoriGetir();
        Task<Urunler> UrunlerVeKategoriGetir(int urunlerId);
        Task<Urunler> UrunSilAsync(int id);
        Task<List<Urunler>> UrunVeFotografGetir(int urunId);

	}
}
