using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminPersonellerController : Controller
    {
        private readonly IPersonellerService _personellerService;
        private readonly IilService _ilService;
        private readonly IMapper _mapper;

        public AdminPersonellerController(IPersonellerService personellerService, IilService ilService, IMapper mapper)
        {
            _personellerService = personellerService;
            _ilService = ilService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminPersonellerIndex()
        {
            var personeller = await _personellerService.PersonelVeKullanicilarAsync();
            return View(personeller);
        }

        public async Task<IActionResult> AdminPersonelKaydetIndex()
        {
            var iller = await _ilService.GetAllAsyncs();
            return View(iller);
        }

        [HttpPost]
        public async Task<IActionResult> AdminPersonelKaydetIndex(Personeller personeller)
        {
            var kullaniciId = HttpContext.Session.GetString("kullanici");
            if (ModelState.IsValid)
            {
                personeller.AktifMi = true;
                personeller.EklenmeTarih = DateTime.Now;
                personeller.KullaniciId = Convert.ToInt32(kullaniciId);
                var sonuc = await _personellerService.AddAsync(personeller);
                if (sonuc != null)
                {
                    ViewBag.mesaj = "Ekleme Başarılı";
                    return RedirectToAction("AdminPersonellerIndex");
                }
            }
            ViewBag.mesaj = "Ekleme Başarısız";
            return View();
        }

        public async Task<IActionResult> AdminPersonelGuncelleIndex(int id)
        {
            var iller = await _ilService.GetAllAsyncs();
            var illerList = iller.ToList();
            var personelGetir = await _personellerService.GetByIdAsync(id);
            var personel = personelGetir;

            var model = new Tuple<List<Iller>, Personeller>(illerList, personel);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminPersonelGuncelleIndex(Personeller personeller)
        {
            var kullaniciId = HttpContext.Session.GetString("kullanici");
            var personellerDTO = _mapper.Map<PersonelGuncelleDTO>(personeller);
            if (ModelState.IsValid)
            {
                var mevcutPersonel = await _personellerService.GetByIdAsync(personellerDTO.Id);
                mevcutPersonel.GuncellenmeTarih = DateTime.Now;
                mevcutPersonel.KullaniciId = Convert.ToInt32(kullaniciId);
                await _personellerService.UpdateAsync(mevcutPersonel);
                ViewBag.mesaj = "Güncelleme başarılı";
                return RedirectToAction("AdminPersonellerIndex");
            }
            ViewBag.mesaj = "Güncelleme başarısız";
            return RedirectToAction("AdminPersonelGuncelleIndex", personeller.Id);
        }

        public async Task<IActionResult> AdminPersonelSilIndex(int id)
        {
            var personelGetir = await _personellerService.GetByIdAsync(id);
            return View(personelGetir);
        }

        [HttpPost, ActionName("AdminPersonelSilIndex")]
        public async Task<IActionResult> AdminPersonelDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _personellerService.PersonelSilAsync(id);
                ViewBag.mesaj = "Personel Pasif Edildi";
                return RedirectToAction("AdminPersonellerIndex");
            }
            ViewBag.mesaj = "Personel Pasif Edilemedi";
            return View(); ;
        }

    }
}
