using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.DTO
{
    public class YetkiErisimDTO
    {
        public int ErisimAlaniId { get; set; }
        public int YetkiId { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}
