using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class ErisimAlanlariGuncelleDTO : BaseListDTO
    {
        public string ControllerAdi { get; set; }
        public string ViewAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
