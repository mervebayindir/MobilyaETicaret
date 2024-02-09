using MobilyaETicaret.Core.MobilyaETicaretDatabase;
#nullable disable

namespace MobilyaETicaret.WEB_API.Models
{
	public class UrunlerViewModel
	{
		public IEnumerable<Urunler> Urunler { get; set; }
		public IEnumerable<Kategoriler> Kategoriler { get; set; }
		public IEnumerable<Fotograflar> Fotograflar { get; set; }
	}
}
