using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
	public class UrunVeFotografDTO
	{
		public int UrunId { get; set; }
		public string UrunAdi { get; set; }
		public int UrunAdet { get; set; }
		public decimal UrunFiyat { get; set; }
		public string FotografUrl { get; set; }
        public decimal Tutar
		{
			get { return UrunAdet * UrunFiyat; }
		}
	}
}
