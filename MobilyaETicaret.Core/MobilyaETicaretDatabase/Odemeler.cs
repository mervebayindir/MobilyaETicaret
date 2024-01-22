using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Odemeler : BaseEntity
    {
        //new List<string>() { "Kredi Kartı", "Havale", "Kapıda Ödeme" };
        public string OdemeTipi { get; set; }
        public int? KartId { get; set; }
        public KrediKartBilgileri KrediKartBilgileri { get; set; }
        public Siparisler Siparisler { get; set; }
    }
}
