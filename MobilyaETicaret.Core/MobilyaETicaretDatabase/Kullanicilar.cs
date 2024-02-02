using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Kullanicilar : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciResim { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciSifre { get; set; }
        public bool PersonelMi { get; set; }
        public int YetkiId { get; set; }
        public Yetkiler Yetkiler { get; set; }
        public ICollection<Yorumlar> Yorumlar { get; set; }
        public ICollection<Siparisler> Siparisler { get; set; }
        public Personeller Personeller { get; set; }
        public Musteriler Musteriler { get; set; }
    }
}
