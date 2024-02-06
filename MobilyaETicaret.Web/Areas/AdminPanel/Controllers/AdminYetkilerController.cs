using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminYetkilerController : Controller
    {
        private readonly IYetkilerService _yetkilerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IYetkiErisimService _yetkiErisimService;
        private readonly IMapper _mapper;

        public AdminYetkilerController(IYetkilerService yetkilerService, IErisimAlanlariService erisimAlanlariService, IYetkiErisimService yetkiErisimService, IMapper mapper)
        {
            _yetkilerService = yetkilerService;
            _erisimAlanlariService = erisimAlanlariService;
            _yetkiErisimService = yetkiErisimService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminYetkilerIndex()
        {
            var yetkiler = await _yetkilerService.GetAllAsyncs();
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            return View(yetkiler);
        }

        public async Task<IActionResult> AdminYetkiKaydetIndex()
        {
            var yetkiler = await _yetkilerService.GetAllAsyncs();
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            return View(yetkiler);
        }

        [HttpPost]
        public async Task<IActionResult> AdminYetkiKaydetIndex(Yetkiler yetkiler, int[] secilenSayfalar)
        {
            YetkiErisim yeniYetkiErisim = new YetkiErisim();
            if (ModelState.IsValid)
            {
                yetkiler.AktifMi = true;
                yetkiler.EklenmeTarih = DateTime.Now;
                var sonuc = await _yetkilerService.AddAsync(yetkiler);
                if (sonuc != null)
                {
                    foreach (var item in secilenSayfalar)
                    {
                        yeniYetkiErisim.YetkiId = yetkiler.Id;
                        yeniYetkiErisim.ErisimAlaniId = item;
                        yeniYetkiErisim.Aciklama = yetkiler.YetkiAdi;
                        yeniYetkiErisim.EklenmeTarihi = DateTime.Now;
                        await _yetkiErisimService.AddAsync(yeniYetkiErisim);
                    }
                    return RedirectToAction("AdminYetkilerIndex");
                }
            }
            return View();
        }

        public async Task<IActionResult> AdminYetkiGuncelleIndex(int id)
        {
            var yetkiGetir = await _yetkilerService.GetByIdAsync(id);
            ViewBag.erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            ViewBag.yetkiErisim = _yetkiErisimService.GetAllQuery(k => k.YetkiId == id).ToList();
            return View(yetkiGetir);
        }

        [HttpPost]
        public async Task<IActionResult> AdminYetkiGuncelleIndex(Yetkiler yetkiler, YetkiErisim yetkiErisim, int[] secilenSayfalar)
        {
            var yetkiDto = _mapper.Map<YetkilerDTO>(yetkiler);
            if (ModelState.IsValid)
            {
                var mevcutYetki = await _yetkilerService.GetByIdAsync(yetkiDto.Id);
                mevcutYetki.GuncellenmeTarih = DateTime.Now;
                mevcutYetki.AktifMi = true;
                await _yetkilerService.UpdateAsync(mevcutYetki);
                var karsilastirmaSayfalari = await _yetkiErisimService.GetAllQueryAsync(k => k.YetkiId == yetkiler.Id);
                if (karsilastirmaSayfalari != null && karsilastirmaSayfalari.Any())
                {
                    var silinecekSayfalar = karsilastirmaSayfalari.Where(item => !secilenSayfalar.Contains(item.ErisimAlaniId)).ToList();
                    if (silinecekSayfalar != null)
                    {
                        await _yetkiErisimService.RemoveRangeAsync(_mapper.Map<List<YetkiErisim>>(silinecekSayfalar));
                    }
                }
                foreach (var item in secilenSayfalar)
                {
                    var erisimVarMi = _yetkiErisimService.GetAllQuery(y => y.YetkiId == yetkiler.Id && y.ErisimAlaniId == item).FirstOrDefault();
                    if (erisimVarMi == null)
                    {
                        yetkiErisim.YetkiId = yetkiler.Id;
                        yetkiErisim.ErisimAlaniId = item;
                        yetkiErisim.Aciklama = yetkiler.YetkiAdi;
                        yetkiErisim.EklenmeTarihi = DateTime.Now; ;
                        await _yetkiErisimService.AddAsync(yetkiErisim);
                    }
                }
                return RedirectToAction("AdminYetkilerIndex");
            }
            return RedirectToAction("AdminYetkiGuncelleIndex", yetkiler.Id);
        }


        public async Task<IActionResult> AdminYetkiSilIndex(int id)
        {
            var yetki = await _yetkilerService.GetByIdAsync(id);
            return View(yetki);
        }

        [HttpPost, ActionName("AdminYetkiSilIndex")]
        public async Task<IActionResult> AdminYetkiDeleteIndex(int id)
        {
            var yetki = await _yetkilerService.GetByIdAsync(id);
            var yetkiErisim = await _yetkiErisimService.GetAllQueryAsync(y => y.YetkiId == id);
            if (ModelState.IsValid)
            {
                await _yetkiErisimService.RemoveRangeAsync(_mapper.Map<List<YetkiErisim>>(yetkiErisim));
                await _yetkilerService.RemoveAsync(_mapper.Map<Yetkiler>(yetki));
                ViewBag.mesaj = "Yetki Pasif Edildi";
            }
            ViewBag.mesaj = "Yetki Pasif Edilemedi";
            return RedirectToAction("AdminYetkilerIndex", yetki.Id);
        }
    }
}
