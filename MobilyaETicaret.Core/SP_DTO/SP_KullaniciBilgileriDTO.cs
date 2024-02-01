using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Core.SP_DTO
{
    public class SP_KullaniciBilgileriDTO
    {
        public int Id { get; set; }
        public string Adoyad { get; set; }
        public string Email { get; set; }
        public DateTime EklenmeTarih { get; set; }
        public DateTime? GuncellenmeTarih { get; set; }
        public bool PersonelMi { get; set; }
        public bool AktifMi { get; set; }
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
    }
}
