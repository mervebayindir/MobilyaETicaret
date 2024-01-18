using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Odemeler : BaseEntity
    {
        public List<string> OdemeTipi { get; set; } = new List<string>() { "Kredi Kartı", "Havale", "Kapıda Ödeme" };
        public int KartId { get; set; }
        public KrediKartBilgileri KrediKartBilgileri { get; set; }
        public Siparisler Siparisler { get; set; }
    }
}
