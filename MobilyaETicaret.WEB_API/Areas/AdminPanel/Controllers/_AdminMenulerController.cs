using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _AdminMenulerController : Controller
    {
        private readonly MenulerAPIService _menulerAPIService;
        private readonly ErisimAlanlariAPIService _erisimAlanlariAPIService;

        public _AdminMenulerController(MenulerAPIService menulerAPIService, ErisimAlanlariAPIService erisimAlanlariAPIService)
        {
            _menulerAPIService = menulerAPIService;
            _erisimAlanlariAPIService = erisimAlanlariAPIService;
        }

        public async Task<IActionResult> _AdminMenulerIndex()
        {
            var menulerList = await _menulerAPIService.Menuler();
            return View(menulerList);
        }

        public async Task<IActionResult> _AdminMenuKaydetIndex()
        {
            var erisimAlaniList = await _erisimAlanlariAPIService.ErisimAlanlari();
            ViewBag.erisimAlanlari = erisimAlaniList;

            var menulerList = await _menulerAPIService.Menuler();
            ViewBag.menuList = menulerList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _AdminMenuKaydetIndex(MenuEkleDTO menuEkleDTO)
        {
            menuEkleDTO.EklenmeTarih = DateTime.Now;
            menuEkleDTO.AktifMi = true;
            var sonuc = await _menulerAPIService.MenuKaydet(menuEkleDTO);
            if (sonuc != null)
            {
                return RedirectToAction("_AdminMenulerIndex");
            }
            return View();
        }
    }
}
