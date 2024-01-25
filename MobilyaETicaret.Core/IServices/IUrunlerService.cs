using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IUrunlerService : IService<Urunler>
    {
        Task<object> UrunSilAsync(int id);
        Task<List<UrunlerveKategoriDTO>> UrunlerVeKategoriGetir();
        Task<UrunlerveKategoriDTO> UrunlerVeKategoriGetir(int urunlerId);
    }
}
