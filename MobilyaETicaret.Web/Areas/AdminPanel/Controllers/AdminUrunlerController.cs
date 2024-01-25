using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminUrunlerController : Controller
    {
        private readonly IUrunlerService _urunlerService;
        private readonly IKategorilerService _kategorilerService;
        private readonly IMapper _mapper;

        public AdminUrunlerController(IUrunlerService urunlerService, IKategorilerService kategorilerService, IMapper mapper)
        {
            _urunlerService = urunlerService;
            _kategorilerService = kategorilerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminUrunlerIndex()
        {
            var urunler = await _urunlerService.UrunlerVeKategoriGetir();
            return View(urunler);
        }

        public async Task<IActionResult> AdminUrunKaydetIndex()
        
        {
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategorilerDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminUrunKaydetIndex(Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                urunler.AktifMi = true;
                urunler.EklenmeTarih = DateTime.Now;
                var sonuc = await _urunlerService.AddAsync(urunler);
                if (sonuc != null)
                {
                    return RedirectToAction("AdminUrunlerIndex");
                }
            }
            TempData["mesaj"] = "Ekleme başarısız";
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategorilerDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminUrunGuncelleIndex(int id)
        {
            var getirUrun = await _urunlerService.UrunlerVeKategoriGetir(id);
            var kategoriList = await _kategorilerService.GetAllAsyncs();
            var kategoriler = kategoriList.ToList();
            var urun = getirUrun;
            var model = new Tuple<List<Kategoriler>, UrunlerveKategoriDTO>(kategoriler,urun);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdminUrunGuncelleIndex(Urunler urunler)
        {
            var urunDTO = _mapper.Map<UrunlerveKategoriDTO>(urunler);
            if (ModelState.IsValid)
            {
                var mevcutUrun = await _urunlerService.GetByIdAsync(urunDTO.Id);
                mevcutUrun.AktifMi = true;
                mevcutUrun.GuncellenmeTarih = DateTime.Now;
                mevcutUrun.UrunAdi = urunDTO.UrunAdi;
                mevcutUrun.UrunFiyat = urunDTO.UrunFiyat;
                mevcutUrun.UrunStok = urunDTO.UrunStok;
                mevcutUrun.Aciklama = urunDTO.Aciklama;
                await _urunlerService.UpdateAsync(_mapper.Map<Urunler>(mevcutUrun));
                TempData["mesaj"] = "Güncelleme başarılı";
                return View();
            }
            TempData["mesaj"] = "Güncelleme başarısız";
            return RedirectToAction("UrunGuncelleIndex", urunler.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdminUrunSilIndex(int id)
        {
            var adresGetir = await _urunlerService.GetByIdAsync(id);
            return View(adresGetir);
        }

        [HttpPost, ActionName("AdminUrunSilIndex")]
        public async Task<IActionResult> AdminUrunDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _urunlerService.UrunSilAsync(id);
                TempData["mesaj"] = "Ürün Pasif Edildi";
                return RedirectToAction("AdminUrunlerIndex");
            }
            TempData["mesaj"] = "Ürün Pasif Edilemedi";
            return View();
        }


        public async Task<IActionResult> UrunResimleri(int id)
        {
            var urunGetir = await _urunlerService.GetByIdAsync(id);
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return View(urunGetir);
        }
        [HttpPost]
        public async Task<IActionResult> UrunResimYukle(int id, IFormFile file)
        {
            //if (file != null && file.Length > 0)
            //{
            //    var fileName = Path.GetFileName(file.FileName);
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //}

            return RedirectToAction("UrunResimleri", new { id = id });
        }
    }
}
