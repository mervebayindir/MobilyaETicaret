using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Models;
using MobilyaETicaret.Web.Oturum;

namespace MobilyaETicaret.Web.Controllers
{
    public class SepetController : BaseController
    {
        private readonly IUrunlerService _urunlerService;

		public SepetController(IUrunlerService urunlerService)
		{
			_urunlerService = urunlerService;
		}

		public async Task<IActionResult> SepetIndex()
        {
			List<SepetElemani> items = HttpContext.Session.GetJson<List<SepetElemani>>("Sepet") ?? new List<SepetElemani>();
			SepetViewModel sepetViewModel = new SepetViewModel
			{
				SepetElemanlari = new List<SepetElemani>(),
			};

			foreach (var item in items)
			{
				var urunVeFotografDTO = await _urunlerService.UrunveFotografURLGetir(item.UrunId);
				if (urunVeFotografDTO != null)
				{
					var sepetElemani = new SepetElemani
					{
						UrunId = urunVeFotografDTO.UrunId,
						UrunAdi = urunVeFotografDTO.UrunAdi,
						UrunAdet = item.UrunAdet,
						UrunFiyat = urunVeFotografDTO.UrunFiyat,
						FotografUrl = urunVeFotografDTO.FotografUrl
					};
					sepetViewModel.SepetElemanlari.Add(sepetElemani);
				}
			}
			sepetViewModel.ToplamTutar = sepetViewModel.SepetElemanlari.Sum(x => x.Tutar);
			return View(sepetViewModel);
		}

        public async Task<IActionResult> SepeteEkle(int id)
        {
            UrunVeFotografDTO urunler = await _urunlerService.UrunveFotografURLGetir(id);			
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
            return Json(new { success = true, message = "Ürün silindi" });
        }

        public async Task<IActionResult> Temizle()
        {
            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("SepetIndex");
        }


    }
}
