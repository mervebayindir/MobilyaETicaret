using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Models
{
    public class UrunDetayViewModal
    {
        public Urunler Urunler { get; set; }
        public IList<Urunler> UrunList { get; set; }
        public string KategoriAdi { get; set; }
        public IEnumerable<Fotograflar> Fotograflar { get; set; }
        //public IEnumerable<Yorumlar> Yorumlar { get; set; }

    }
}
