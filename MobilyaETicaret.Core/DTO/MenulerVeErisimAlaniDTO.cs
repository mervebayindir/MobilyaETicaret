﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class MenulerVeErisimAlaniDTO : BaseListDTO
    {
        public string MenuAdi { get; set; }
        public int? UstMenuId { get; set; }
        public int MenuSirasi { get; set; }
        public string Aciklama { get; set; }
        public string KullaniciAdiSoyadi { get; set; }
        public ErisimAlanlariGuncelleDTO ErisimAlanlari { get; set; }
    }
}