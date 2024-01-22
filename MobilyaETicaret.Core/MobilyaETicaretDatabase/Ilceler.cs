using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Ilceler
    {
        public int IlceKodu { get; set; }
        public int IlKodu { get; set; }
        public string IlceAdi { get; set; }
        public Iller Iller { get; set; }
        public ICollection<Adresler> Adresler { get; set; }
    }
}
