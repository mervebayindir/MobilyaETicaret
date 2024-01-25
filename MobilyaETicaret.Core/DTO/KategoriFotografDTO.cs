using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.DTO
#nullable disable
{
    public class KategoriFotografDTO :BaseListDTO
    {
        public IFormFile FotografId { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
