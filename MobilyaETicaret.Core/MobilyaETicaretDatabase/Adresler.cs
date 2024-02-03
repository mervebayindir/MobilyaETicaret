﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class Adresler : BaseEntity
    {
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string PostaKodu { get; set; }
        public int IlKodu { get; set; }
        public int IlceKodu { get; set; }
        public int MusteriId { get; set; }
        public Ilceler Ilce { get; set; }
        public Musteriler Musteriler { get; set; }
        public Siparisler Siparisler { get; set; }
    }
}
