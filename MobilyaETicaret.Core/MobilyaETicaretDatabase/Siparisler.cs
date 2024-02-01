using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Siparisler : BaseEntity
    {
        public int ToplamUrunAdet { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int MusteriId { get; set; }
        public int OdemeId { get; set; }
        public Odemeler Odemeler { get; set; }
        public ICollection<SiparisDetay> SiparisDetay { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public Musteriler Musteriler { get; set; }
    }
}
