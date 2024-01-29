using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace MobilyaETicaret.Core.DTO
{
	public class FotograflarVeUrunlerDTO : BaseListDTO
	{
		public List<string> FotografYolu { get; set; }

		public string FotografAciklamasi { get; set; }

		public byte? FotografSirasi { get; set; }

		public int UrunId { get; set; }

		public UrunGuncelleDTO Urunler { get; set; }
	}
}
