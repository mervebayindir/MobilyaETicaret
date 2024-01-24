using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class KategoriFotograflari :BaseEntity
    {
        public string FotografYolu { get; set; }
        public string FotografAdi { get; set; }
        public string FotografAciklamasi { get; set; }
        public int KategoriId { get; set; }
        public Kategoriler Kategoriler { get; set; }
    }
}
