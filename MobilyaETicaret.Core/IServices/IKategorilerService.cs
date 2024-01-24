using Microsoft.AspNetCore.Http;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IKategorilerService : IService<Kategoriler>
    {
        IQueryable<Kategoriler> KategoriListesi();
        Task<object> KategoriSilAsync(int id);


    }
}
