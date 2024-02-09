using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminUrunlerController : Controller
    {
        private readonly UrunlerAPIService _urunlerAPIService;
        private readonly KategorilerAPIService _kategorilerAPIService;

        public _AdminUrunlerController(UrunlerAPIService urunlerAPIService, KategorilerAPIService kategorilerAPIService)
        {
            _urunlerAPIService = urunlerAPIService;
            _kategorilerAPIService = kategorilerAPIService;
        }

        public async Task<IActionResult> _AdminUrunlerIndex()
        {
            var urunList = await _urunlerAPIService.Urunler();
            return View(urunList);
        }

        public async Task<IActionResult> _AdminUrunKaydetIndex()
        {
            var kategoriList = await _kategorilerAPIService.Kategoriler();
            ViewBag.kategoriler = kategoriList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _AdminUrunKaydetIndex(UrunEkleDTO urunEkleDTO)
        {
            urunEkleDTO.AktifMi = true;
            urunEkleDTO.EklenmeTarih = DateTime.Now;
            await _urunlerAPIService.UrunKaydet(urunEkleDTO);
            return RedirectToAction("_AdminUrunlerIndex", "_AdminUrunler", "AdminPanel");
        }
    }
}
