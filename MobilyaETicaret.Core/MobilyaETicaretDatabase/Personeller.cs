using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Personeller : BaseEntity
    {
		private DateTime _myDateTime;
		public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public decimal PersonelMaasi { get; set; }
        public DateTime MaasOdemeTarihi 
        {
			get { return _myDateTime; }
			set { _myDateTime = value; }
		}
        public bool MedeniHali { get; set; }
        public string CalistigiFirma { get; set; }
        public string PersonelHakkinda { get; set; }
        public string YasadigiSehir { get; set; }
        public Kullanicilar Kullanicilar { get; set; }

		public void SetDayOfMonth(int day)
		{
			_myDateTime = new DateTime(_myDateTime.Year, _myDateTime.Month, day,
									   _myDateTime.Hour, _myDateTime.Minute, _myDateTime.Second);
		}

	}
}
