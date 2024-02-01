using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Models
{
    public class SepetViewModel
    {
        public List<SepetElemani> SepetElemanlari { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
