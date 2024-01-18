using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class KrediKartBilgileri
    {
        public int KartId { get; set; }
        public int CVC { get; set; }
        public string KartSeriNo { get; set; }
        public string KartSahibiAdiSoyadi { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public List<Odemeler> Odemeler { get; set; }
    }
}
