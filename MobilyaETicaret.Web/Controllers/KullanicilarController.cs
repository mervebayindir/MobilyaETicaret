using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Web.Oturum;

namespace MobilyaETicaret.Web.Controllers
{
	public class KullanicilarController : Controller
	{
		private readonly IKullanicilarService _kullanicilarService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public KullanicilarController(IKullanicilarService kullanicilarService, IHttpContextAccessor httpContextAccessor)
		{
			_kullanicilarService = kullanicilarService;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> KullaniciGirisIndex(int? id=null)
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> KullaniciGirisIndex(Kullanicilar kullanicilar)
		{
			var kullaniciGiris = await _kullanicilarService.Giris(kullanicilar.KullaniciEmail, kullanicilar.KullaniciSifre);

			if (kullaniciGiris != null)
			{
                string AdSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
                string yetki = kullaniciGiris.Yetkiler?.Id.ToString();
				if (yetki != null)
				{
                    _httpContextAccessor.HttpContext.Session.SetJson("userName", AdSoyad);
                    _httpContextAccessor.HttpContext.Session.SetJson("userYetki", yetki);
                    TempData["kullaniciId"] = kullaniciGiris.KullaniciId;
                }
                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            TempData["mesaj"] = "Kullanıcı adı veya şifre hatalı.";
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
				if (sonuc > 0 )
				{
                    return RedirectToAction("AnasayfaIndex");
                }
                ViewBag.mesaj = "Kayıt sırasında bir hata oluştu.";
            }
            return View(kullanicilar);
        }
    }
}
