using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class UrunlerDTO : BaseDTO
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int UrunStok { get; set; }
        public decimal UrunFiyat { get; set; }
        public int KategoriId { get; set; }
    }
}
