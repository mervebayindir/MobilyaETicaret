using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
	public class AdminPersonellerController : Controller
	{
		private readonly IPersonellerService _personellerService;
		private readonly IilService _ilService;

		public AdminPersonellerController(IPersonellerService personellerService, IilService ilService)
		{
			_personellerService = personellerService;
			_ilService = ilService;
		}

		public async Task<IActionResult> AdminPersonellerIndex()
		{
			var personeller = await _personellerService.PersonelVeKullanicilarAsync();
			return View(personeller);
		}

		public async Task<IActionResult> AdminPersonelKaydetIndex()
		{
			var iller = await _ilService.GetAllAsyncs();
			var illerList = iller.ToList();
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
	}
}
