using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Urunler : BaseEntity
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int UrunStok { get; set; }
        public decimal UrunFiyat { get; set; }
        public int KategoriId { get; set; }
        public Kategoriler Kategoriler { get; set; }
        public ICollection<Yorumlar> Yorumlar { get; set; }
        public ICollection<Fotograflar> Fotograflar { get; set; }
        public ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
