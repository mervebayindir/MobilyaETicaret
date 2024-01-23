﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
	public class AdminAdreslerController : Controller
	{
        private readonly IilService _ilService;
		private readonly IAdreslerService _adreslerService;
        private readonly IMapper _mapper;

        public AdminAdreslerController(IAdreslerService adreslerService, IilService ilService, IMapper mapper)
        {
            _adreslerService = adreslerService;
            _ilService = ilService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminAdreslerIndex()
		{
			var adresMusteri = await _adreslerService.AdresVeMusteri();
			return View(adresMusteri);
		}

        public async Task<IActionResult> AdminAdresKaydetIndex()
        {
            var iller = await _ilService.IllerListele();
            TempData["iller"] = iller;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminAdresKaydetIndex(Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                adresler.AktifMi = true;
                adresler.EklenmeTarih = DateTime.Now;
                adresler.MusteriId = 1;
                var sonuc = await _adreslerService.AddAsync(adresler);
                if (sonuc != null)
                {
                    return RedirectToAction("AdminAdreslerIndex");
                }
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Ekleme başarısız</div>";
            return View();
        }

        public async Task<IActionResult> AdminAdresGuncelleIndex(int id)
        {
            var adresGetir = await _adreslerService.GetByIdAsync(id);
            var iller = await _ilService.IllerListele();

            var illerList = iller.ToList();
            var adres = adresGetir;

            var secilenIlKodu = adres.IlKodu;

            var ilceler = await _ilService.GetIllerWithIlceler(secilenIlKodu);

            var ilcelerList = ilceler.ToList();

            var secilenIlceKodu = adres.IlceKodu;

            var model = new Tuple<List<Iller>, List<Ilceler>, Adresler, int?, int?>(illerList, ilcelerList, adres, secilenIlKodu, secilenIlceKodu);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminAdresGuncelleIndex(Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                adresler.MusteriId = 1;
                adresler.GuncellenmeTarih = DateTime.Now;
                adresler.AktifMi = true;
                await _adreslerService.UpdateAsync(_mapper.Map<Adresler>(adresler));
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Güncelleme başarılı</div>";
                return RedirectToAction("AdminAdreslerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Güncelleme başarısız</div>";
            return RedirectToAction("AdminAdresGuncelleIndex", adresler.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdminAdresSilIndex(int id)
        {
            var adresGetir = await _adreslerService.GetByIdAsync(id);
            return View(adresGetir);
        }

        [HttpPost, ActionName("AdminAdresSilIndex")]
        public async Task<IActionResult> AdminAdresDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _adreslerService.AdresSilAsync(id);
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Adres Pasif Edildi</div>";
                return RedirectToAction("AdreslerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Adres Pasif Edilemedi</div>";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetIlveIlce(int ilId)
        {
            var ilceler = await _ilService.GetIllerWithIlceler(ilId);
            var ilceList = ilceler.Select(i => new
            {
                Value = i.IlceKodu,
                Text = i.IlceAdi
            });
            return Json(ilceList);
        }
    }
}
