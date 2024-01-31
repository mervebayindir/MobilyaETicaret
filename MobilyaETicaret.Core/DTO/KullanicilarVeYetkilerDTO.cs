using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
	public class KullanicilarVeYetkilerDTO: BaseListDTO
	{
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string KullaniciEmail { get; set; }
		public bool PersonelMi { get; set; }
		public YetkilerDTO Yetkiler { get; set; }
		public int YetkiId { get; set; }
	}
}
