using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Web.Models;
using MobilyaETicaret.Web.Oturum;

namespace MobilyaETicaret.Web.Component
{
    public class SepetToplamListe : ViewComponent
    {
        //private readonly IUrunlerService _urunlerService;
        public SepetToplamListe()
        {
        }
        public IViewComponentResult Invoke()
        {
            List<SepetElemani> sepet = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet") ?? new List<SepetElemani>();
            SepetViewModel sepetViewModel = new()
            {
                SepetElemanlari = sepet,
                ToplamTutar = sepet.Sum(x => x.UrunAdet * x.UrunFiyat)
            };
            return View(sepetViewModel);
        }
    }
}
