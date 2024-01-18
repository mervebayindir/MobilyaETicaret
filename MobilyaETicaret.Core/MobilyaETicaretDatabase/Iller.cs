using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Iller
    {
        public int IlKodu { get; set; }
        public string IlAdi { get; set; }
        public ICollection<Ilceler> Ilceler { get; set; }
    }
}
