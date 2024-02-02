using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Oturum;

namespace MobilyaETicaret.Web.Controllers
{
    public class KullanicilarController : BaseController
    {
        private readonly IKullanicilarService _kullanicilarService;
        public KullanicilarController(IKullanicilarService kullanicilarService)
        {
            _kullanicilarService = kullanicilarService;
        }

        public async Task<IActionResult> KullaniciGirisIndex()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> KullaniciGirisIndex(Kullanicilar kullanicilar)
        {
            var kullaniciGiris = await _kullanicilarService.Giris(kullanicilar.KullaniciEmail, kullanicilar.KullaniciSifre);
            if (kullaniciGiris != null)
            {
                string AdSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi.ToLower();
                string yetki = kullaniciGiris.YetkiId.ToString();
                string yetkiAdi = kullaniciGiris.Yetkiler.YetkiAdi;

                //_httpContextAccessor.HttpContext.Session.SetJson("userName", AdSoyad);                    
                //_httpContextAccessor.HttpContext.Session.SetJson("userYetki", yetki);
                HttpContext.Session.SetString("userName", AdSoyad);
                HttpContext.Session.SetString("userYetki", yetki);
                HttpContext.Session.SetString("yetki", yetkiAdi);
                TempData["kullaniciId"] = kullaniciGiris.KullaniciId;

                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            ViewBag.hataMesaji = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        public IActionResult KullaniciKayıtOlIndex()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciKayıtOlIndex(Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _kullanicilarService.KullaniciEkleAsync(kullanicilar.Adi, kullanicilar.Soyadi, kullanicilar.KullaniciEmail, kullanicilar.KullaniciSifre, false, 2, true, DateTime.Now);
                if (sonuc > 0)
                {
                    string AdSoyad = kullanicilar.Adi + " " + kullanicilar.Soyadi;
                    HttpContext.Session.SetJson("userName", AdSoyad);
                    return RedirectToAction("AnasayfaIndex", "Anasayfa");
                }
                ViewBag.mesaj = "Kayıt sırasında bir hata oluştu.";
            }
            return View(kullanicilar);
        }

        public async Task<IActionResult> KullaniciCikisIndex()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("KullaniciGirisIndex");
        }

    }
}
