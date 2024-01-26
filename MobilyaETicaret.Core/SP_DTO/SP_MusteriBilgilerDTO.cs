using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.SP_DTO
{
    public class SP_MusteriBilgilerDTO
    {
        public int MusteriId { get; set; }
        public string MusteriAdSoyad { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefonu { get; set; }
        public string KullaniciEmail { get; set; }
        public int? SiparisId { get; set; }
        public decimal? ToplamFiyat { get; set; }
        public bool AktifMi { get; set; }
        public DateTime? SiparisTarihi { get; set; }
        public DateTime EklenmeTarih { get; set; }

    }
}
