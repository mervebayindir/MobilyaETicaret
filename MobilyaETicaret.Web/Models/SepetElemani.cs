using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Models
{
    public class SepetElemani
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunAdet { get; set; }
        public Decimal UrunFiyat { get; set; }
		public string FotografUrl { get; set; }
		public decimal Tutar 
        {
            get { return UrunAdet * UrunFiyat; } 
        }
        public SepetElemani()
        {
             
        }
        public SepetElemani(UrunVeFotografDTO urunler)
        {
            UrunId = urunler.UrunId;
            UrunAdi = urunler.UrunAdi;
            UrunAdet = 1;
            UrunFiyat = urunler.UrunFiyat;
            FotografUrl = urunler.FotografUrl;
        }
    }
}
