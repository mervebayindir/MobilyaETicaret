﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class KrediKartBilgileri
    {
        public int KartId { get; set; }
        public string CVC { get; set; }
        public string KartSeriNo { get; set; }
        public string KartSahibiAdiSoyadi { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public List<Odemeler> Odemeler { get; set; }
    }
}
