using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class MusteriEkleDTO : BaseDTO
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefonu { get; set; }
        public string Meslek { get; set; }
        public int KullaniciId { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
