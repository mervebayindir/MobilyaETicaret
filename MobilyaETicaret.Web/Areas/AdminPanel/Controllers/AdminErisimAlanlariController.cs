using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminErisimAlanlariController : Controller
    {
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IMapper _mapper;

        public AdminErisimAlanlariController(IErisimAlanlariService erisimAlanlariService, IMapper mapper)
        {
            _erisimAlanlariService = erisimAlanlariService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminErisimAlanlariIndex()
        {
            var erisimAlanlari = await _erisimAlanlariService.GetAllAsyncs();
            return View(erisimAlanlari);
        }

        public async Task<IActionResult> AdminErisimAlaniKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminErisimAlaniKaydetIndex(ErisimAlanlari erisimAlanlari)
        {
            if (ModelState.IsValid)
            {
                erisimAlanlari.AktifMi = true;
                erisimAlanlari.EklenmeTarih = DateTime.Now;
                var sonuc = await _erisimAlanlariService.AddAsync(erisimAlanlari);
                if (sonuc != null)
                {
                    ViewBag.mesaj = "Ekleme Başarılı";
                    return RedirectToAction("AdminErisimAlanlariIndex");
                }
            }
            ViewBag.mesaj = "Ekleme Başarısız";
            return View();
        }

        public async Task<IActionResult> AdminErisimAlaniGuncelleIndex(int id)
        {
            var erisimAlaniGetir = await _erisimAlanlariService.GetByIdAsync(id);
            return View(erisimAlaniGetir);
        }

        [HttpPost]
        public async Task<IActionResult> AdminErisimAlaniGuncelleIndex( ErisimAlanlari erisimAlanlari)
        {
            var erisimAlaniDTO = _mapper.Map<ErisimAlanlariGuncelleDTO>(erisimAlanlari);
            if (ModelState.IsValid)
            {
                var mevcutErisimAlani = await _erisimAlanlariService.GetByIdAsync(erisimAlaniDTO.Id);
                mevcutErisimAlani.GuncellenmeTarih = DateTime.Now;
                await _erisimAlanlariService.UpdateAsync(mevcutErisimAlani);
                ViewBag.mesaj = "Güncelleme başarılı";
                return RedirectToAction("AdminErisimAlanlariIndex");
            }
            ViewBag.mesaj = "Güncelleme başarısız";
            return View("AdminErisimAlaniGuncelleIndex", erisimAlanlari.Id);
        }

        public async Task<IActionResult> AdminErisimAlaniSilIndex(int id)
        {
            var erisimAlaniGetir = await _erisimAlanlariService.GetByIdAsync(id);
            return View(erisimAlaniGetir);
        }

        [HttpPost, ActionName("AdminErisimAlaniSilIndex")]
        public async Task<IActionResult> AdminErisimAlaniDeleteIndex(int id)
        {
            var erisimAlani = await _erisimAlanlariService.GetByIdAsync(id);
            if (erisimAlani != null)
            {
                erisimAlani.GuncellenmeTarih = DateTime.Now;
                await _erisimAlanlariService.ErisimAlaniSilAsync(erisimAlani.Id);
                ViewBag.mesaj = "Erisim Alanı Pasif Edildi";
                return RedirectToAction("AdminErisimAlanlariIndex");
            }
            ViewBag.mesaj = "Erisim Alanı Pasif Edilemedi";
            return View();
        }

    }
}
