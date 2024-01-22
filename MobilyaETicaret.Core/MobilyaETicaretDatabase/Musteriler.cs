using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Musteriler : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefonu { get; set; }
        public string Meslek { get; set; }
        public DateTime DogumTarihi { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public ICollection<Adresler> Adresler { get; set; }
        public ICollection<Siparisler> Siparisler { get; set; }
    }
}
