using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class KategoriGuncelleDTO :BaseListDTO
    {
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public KategoriFotograflari KategoriFotograflari { get; set; }
    }
}
