using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Personeller : BaseEntity
    {
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public decimal PersonelMaasi { get; set; }
        public DateTime MaasOdemeTarihi { get; set; }
        public bool MedeniHali { get; set; }
        public string CalistigiFirma { get; set; }
        public string PersonelHakkinda { get; set; }
        public string YasadigiSehir { get; set; }
        public int PersonelKullaniciBilgileriId { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public Kullanicilar PersonelKullaniciBilgileri { get; set; }
    }
}
