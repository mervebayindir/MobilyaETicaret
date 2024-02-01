using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.SP_DTO
{
    public class Sp_SiparisBilgileriDTO
    {
        public string OdemeTipi { get; set; }
        public int SiparisId { get; set; }
        public decimal ToplamFiyat { get; set; }
        public bool AktifMi { get; set; }
        public DateTime EklenmeTarih { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public string Telefonu { get; set; }
        public string UrunAdi { get; set; }
    }
}
