using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class SiparisDetayDTO
    {
        public int SiparisDetayId { get; set; }
        public string OdemeTipi { get; set; }
        public string UrunAdi { get; set; }
        public int UrunAdet { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public string Telefonu { get; set; }
        public decimal UrunFiyat { get; set; }
        public string Adres { get; set; }
        public int SiparisId { get; set; }
    }
}
