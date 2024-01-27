using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminMenulerController : Controller
    {
        private readonly IMenulerService _menulerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IMapper _mapper;

        public AdminMenulerController(IMenulerService menulerService, IErisimAlanlariService erisimAlanlariService, IMapper mapper)
        {
            _menulerService = menulerService;
            _erisimAlanlariService = erisimAlanlariService;
            _mapper = mapper;
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
                var sonuc = await _menulerService.AddAsync(menuler);
                if (sonuc != null)
                {
                    return RedirectToAction("AdminMenulerIndex");
                }
            }         
            TempData["mesaj"] = "Ekleme başarısız";
            return View(menuler);
        }
    }
}
