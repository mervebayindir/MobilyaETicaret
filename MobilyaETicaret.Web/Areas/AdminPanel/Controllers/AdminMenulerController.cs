using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;

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
                    ViewBag.mesaj = "Ekleme Başarılı";
                    return RedirectToAction("AdminMenulerIndex");
                }
            }
            ViewBag.mesaj = "Ekleme başarısız";
            return RedirectToAction("AdminMenuKaydetIndex", menuler);
        }

        public async Task<IActionResult> AdminMenuGuncelleIndex(int id)
        {
            var menuGetir = await _menulerService.MenulerVeErisimAlanlariAsync(id);
            var menu = menuGetir;

            var erisimAlaniList = await _erisimAlanlariService.GetAllAsyncs();
            var erisimAlani = erisimAlaniList.ToList();

            var model = new Tuple<List<ErisimAlanlari>, MenulerVeErisimAlaniDTO>(erisimAlani, menu);

            var menuList = await _menulerService.GetAllAsyncs();
            var menulerDTO = _mapper.Map<List<MenulerVeErisimAlaniDTO>>(menuList);
            ViewBag.menuList = menulerDTO;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminMenuGuncelleIndex(Menuler menuler)
        {
            var menulerDTO = _mapper.Map<MenulerVeErisimAlaniDTO>(menuler);
            if (ModelState.IsValid)
            {
                var mevcutMenu = await _menulerService.GetByIdAsync(menulerDTO.Id);
                mevcutMenu.AktifMi = true;
                mevcutMenu.GuncellenmeTarih = DateTime.Now;
                await _menulerService.UpdateAsync(mevcutMenu);
                ViewBag.mesaj = "Güncelleme başarılı";
                return RedirectToAction("AdminMenulerIndex");
            }
            ViewBag.mesaj = "Güncelleme başarısız";
            return RedirectToAction("AdminMenuGuncelleIndex", menuler.Id);
        }

        public async Task<IActionResult> AdminMenuSilIndex(int id)
        {
            var menuGetir = await _menulerService.GetByIdAsync(id);
            return View(menuGetir);
        }

        [HttpPost, ActionName("AdminMenuSilIndex")]
        public async Task<IActionResult> AdminMenuDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _menulerService.MenuSilAsync(id);
                ViewBag.mesaj = "Menu Pasif Edildi";
                return RedirectToAction("AdminMenulerIndex");
            }
            ViewBag.mesaj = "Menu Pasif Edilemedi";
            return View();
        }
    }
}
