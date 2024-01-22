﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Yetkiler : BaseEntity
    {
        public string YetkiAdi { get; set; }
        public ICollection<Kullanicilar> Kullanicilar { get; set; }
        public ICollection<YetkiErisim> YetkiErisimleri { get; set; }
    }
}
