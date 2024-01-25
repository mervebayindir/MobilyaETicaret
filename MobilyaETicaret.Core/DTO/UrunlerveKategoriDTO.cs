﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class UrunlerveKategoriDTO : BaseListDTO
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int UrunStok { get; set; }
        public decimal UrunFiyat { get; set; }
        public KategorilerDTO Kategoriler { get; set; }
        public string KullaniciAdiSoyadi { get; set; }
    }
}
