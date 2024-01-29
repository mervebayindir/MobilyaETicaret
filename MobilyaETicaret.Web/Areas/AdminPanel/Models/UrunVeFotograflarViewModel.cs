using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Models
{
    public class UrunVeFotograflarViewModel
    {
        public Urunler Urun { get; set; }
        public List<string> FotografYolu { get; set; }
    }
}
