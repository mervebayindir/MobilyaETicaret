using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Models
{
	public class UrunlerViewModel
	{
		public IEnumerable<Urunler> Urunler { get; set; }
		public IEnumerable<Kategoriler> Kategoriler { get; set; }
		public IEnumerable<Fotograflar> Fotograflar { get; set; }
	}
}
