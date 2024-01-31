using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;
using MobilyaETicaret.Web.Oturum;

namespace MobilyaETicaret.Web.Controllers
{
    public class SepetController : Controller
    {
        private readonly IUrunlerService _urunlerService;

        public SepetController(IUrunlerService urunlerService)
        {
            _urunlerService = urunlerService;
        }

        public IActionResult SepetIndex()
        {
            List<SepetElemani> items = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet") ?? new List<SepetElemani>();
            SepetViewModel sepetViewModel = new()
            {
                SepetElemanlari = items,
                ToplamTutar = items.Sum(x => x.UrunAdet * x.UrunFiyat)
            };
            return View();
        }

        public async Task<IActionResult> SepeteEkle(int id)
        {
            Urunler urunler = await _urunlerService.GetByIdAsync(id);
            List<SepetElemani> items = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet") ?? new List<SepetElemani>();
            SepetElemani sepetElemani = items.FirstOrDefault(x => x.UrunId == id);
            if (sepetElemani == null)
            {
                items.Add(new SepetElemani(urunler));
            }
            else
            {
                sepetElemani.UrunAdet += 1;
            }
            HttpContext.Session.SetJson("Sepet", items);
            TempData["mesaj"] = "Ürün Sepete Eklenmiştir";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Azaltma(int id)
        {
            List<SepetElemani> sepet = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet");
            SepetElemani sepetElemani = sepet.Where(c => c.UrunId == id).FirstOrDefault();
            if (sepetElemani.UrunAdet > 1)
            {
                sepetElemani.UrunAdet -= 1;
            }
            else
            {
                sepet.RemoveAll(c => c.UrunId == id);
            }
            if (sepet.Count > 0)
            {
                HttpContext.Session.SetJson("Sepet", sepet);
            }
            TempData["mesaj"] = "Ürün Sepetten Silindi";
            return RedirectToAction("SepetIndex");
        }


        public async Task<IActionResult> Sil(int id)
        {
            List<SepetElemani> sepet = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet");
            sepet.RemoveAll(c => c.UrunId == id);
            if (sepet.Count > 0)
            {
                HttpContext.Session.Remove("Sepet");
            }
            else
            {
                HttpContext.Session.SetJson("Sepet", sepet);
            }
            TempData["mesaj"] = "Ürün Sepeti Silindi";
            return RedirectToAction("SepetIndex");
        }

        public async Task<IActionResult> Temizle()
        {
            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("SepetIndex");
        }

    }
}
