using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminKategorilerController : Controller
    {
        private readonly KategorilerAPIService _kategorilerAPIService;

        public _AdminKategorilerController(KategorilerAPIService kategorilerAPIService)
        {
            _kategorilerAPIService = kategorilerAPIService;
        }

        public async Task<IActionResult> _AdminKategorilerIndex()
        {
            var ketegoriList = await _kategorilerAPIService.Kategoriler();
            return View(ketegoriList);
        }

        public async Task<IActionResult> _AdminKategoriKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _AdminKategoriKaydetIndex(KategoriFotografDTO kategoriFotografDTO)
        {
            kategoriFotografDTO.AktifMi = true;
            kategoriFotografDTO.EklenmeTarih = DateTime.Now;
            await _kategorilerAPIService.KategoriKaydet(kategoriFotografDTO);
            return RedirectToAction("_AdminKategorilerIndex");
        }
    }
}
