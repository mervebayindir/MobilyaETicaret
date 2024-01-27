using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminMenulerController : Controller
    {
        private readonly IMenulerService _menulerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;

        public AdminMenulerController(IMenulerService menulerService, IErisimAlanlariService erisimAlanlariService)
        {
            _menulerService = menulerService;
            _erisimAlanlariService = erisimAlanlariService;
        }

        public async Task<IActionResult> AdminMenulerIndex()
        {
            var menuler = await _menulerService.MenulerVeErisimAlanlariAsync();
            return View(menuler);
        }

        public async Task<IActionResult> AdminMenuKaydetIndex()
        
        
        
        
        
        {
            var erisimAlaniList = await _erisimAlanlariService.GetAllAsyncs();
            ViewBag.erisimAlanlari = erisimAlaniList;

            var menuList = await _menulerService.GetAllAsyncs();
            ViewBag.menuList = menuList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminMenuKaydetIndex(Menuler menuler)
        {
            if (ModelState.IsValid)
            {
                menuler.EklenmeTarih = DateTime.Now;
                menuler.AktifMi = true;
                //menuler.UstMenuId = null;
                var sonuc = await _menulerService.AddAsync(menuler);
                if (sonuc != null)
                {
                    return RedirectToAction("AdminMenulerIndex");
                }
               
            }
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    // error.ErrorMessage içindeki hataları inceleyin
                }
            }
            TempData["mesaj"] = "Ekleme başarısız";
            return View();
        }
    }
}
