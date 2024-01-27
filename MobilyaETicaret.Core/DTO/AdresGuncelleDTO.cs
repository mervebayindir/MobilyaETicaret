using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class AdresGuncelleDTO : BaseListDTO
    { 
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string PostaKodu { get; set; }
        public int IlKodu { get; set; }
        public int IlceKodu { get; set; }
       
    }
}
