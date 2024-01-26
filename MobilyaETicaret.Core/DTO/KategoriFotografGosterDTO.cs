using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class KategoriFotografGosterDTO : BaseListDTO
    {
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public string FotografYolu { get; set; }
    }
}
