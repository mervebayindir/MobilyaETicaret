using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class SiparislerDTO 
    {
        public int SiparisId { get; set; }
        public bool AktifMi { get; set; }
        public DateTime EklenmeTarih { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public string Telefonu { get; set; }
        public string OdemeTipi { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int ToplamUrunAdeti { get; set; }
        public int SiparisDetayId { get; set; }
    }
}
