using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.MobilyaETicaretDatabase
{
    public class ErisimAlanlari : BaseEntity
    {
        public string ControllerAdi { get; set; }
        public string ViewAdi { get; set; }
        public string Aciklama { get; set; }
        public ICollection<YetkiErisim> YetkiErisimleri { get; set; }
        public Menuler Menuler { get; set; }
    }
}
