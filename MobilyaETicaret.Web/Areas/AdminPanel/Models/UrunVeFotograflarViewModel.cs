using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Models
{
    public class UrunVeFotograflarViewModel
    {
        public UrunGuncelleDTO Urun { get; set; }
        //public List<string> FotografYolu { get; set; }
        public List<FotograflarDTO> Fotograflar { get; set; }
    }
}
