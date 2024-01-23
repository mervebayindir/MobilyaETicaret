using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
	public class AdminAnasayfaController : Controller
	{
		private readonly IAdreslerService _adreslerService;

        public AdminAnasayfaController(IAdreslerService adreslerService)
        {
            _adreslerService = adreslerService;
        }

        public async Task<IActionResult> AdminAnasayfaIndex()
		{
			var adresveMusteri = await _adreslerService.AdresVeMusteri();
			return View(adresveMusteri);
		}
	}
}
