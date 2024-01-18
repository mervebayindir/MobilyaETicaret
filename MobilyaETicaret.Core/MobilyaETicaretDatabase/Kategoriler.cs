using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Kategoriler : BaseEntity
    {
        public int FotografId { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Urunler> Urunler { get; set; }

        public Fotograflar Fotograflar { get; set; }
    }
}
