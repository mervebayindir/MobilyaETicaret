using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class SiparisDetay
    {
        public int SiparisDetayId { get; set; }
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public int UrunAdet { get; set; }
        public decimal BirimFiyat { get; set; }
        public Siparisler Siparisler { get; set; }
        public Urunler Urunler { get; set; }
    }
}
