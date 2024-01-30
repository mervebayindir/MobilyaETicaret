using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminKullanicilarController : Controller
    {
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IMapper _mapper;

        public AdminKullanicilarController(IKullanicilarService kullanicilarService, IMapper mapper)
        {
            _kullanicilarService = kullanicilarService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdminKullanicilarIndex()
        {
            var kullanicilar = await _kullanicilarService.KullaniciVeYetkiGetirAsync();
            return View(kullanicilar);
        }

        public async Task<IActionResult> AdminKullaniciGuncelleIndex(int id)
        {
            var kullaniciGetir = await _kullanicilarService.KullaniciVeYetkiGetirAsync(id);
            var kullanici = kullaniciGetir;
            //var yetki = await
            return View();
        }

        [HttpPost]
        public IActionResult AdminKullaniciGuncelleIndex()
        {
            return View();
        }
    }
}
