using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API.Areas.AdminPanel.Controllers
{
	public class _AdminYetkilerController : Controller
	{
		private readonly YetkilerAPIService _yetkilerAPIService;
		private readonly ErisimAlanlariAPIService _erisimAlanlariAPIService;
		private readonly YetkiErisimAPIService _yetkiErisimAPIService;
        private readonly IMapper _mapper;

        public _AdminYetkilerController(YetkilerAPIService yetkilerAPIService, ErisimAlanlariAPIService erisimAlanlariAPIService, YetkiErisimAPIService yetkiErisimAPIService, IMapper mapper)
        {
            _yetkilerAPIService = yetkilerAPIService;
            _erisimAlanlariAPIService = erisimAlanlariAPIService;
            _yetkiErisimAPIService = yetkiErisimAPIService;
            _mapper = mapper;
        }

        public async Task<IActionResult> _AdminYetkilerIndex()
		{
			var yetkiList = await _yetkilerAPIService.Yetkiler();
			ViewBag.erisimAlani = await _erisimAlanlariAPIService.ErisimAlanlari();
			return View(yetkiList);
		}

        public async Task<IActionResult> _AdminYetkiKaydetIndex()
        {
            var yetkiList = await _yetkilerAPIService.Yetkiler();
            ViewBag.erisimAlani = await _erisimAlanlariAPIService.ErisimAlanlari();
            return View(yetkiList);
        }

		[HttpPost]
        public async Task<IActionResult> _AdminYetkiKaydetIndex(YetkiGuncelleDTO yetkiEkleDTO, int[] secilenSayfalar)
        {
            YetkiErisim yeniYetkiErisim = new YetkiErisim();
            yetkiEkleDTO.AktifMi = true;
            yetkiEkleDTO.EklenmeTarih = DateTime.Now;
            var sonuc = await _yetkilerAPIService.YetkiKaydet(yetkiEkleDTO);
            if (sonuc != null)
            {
                foreach (var item in secilenSayfalar)
                {
                    yeniYetkiErisim.YetkiId = yetkiEkleDTO.Id;
                    yeniYetkiErisim.ErisimAlaniId = item;
                    yeniYetkiErisim.Aciklama = yetkiEkleDTO.YetkiAdi;
                    yeniYetkiErisim.EklenmeTarihi = DateTime.Now;
                    
                    await _yetkiErisimAPIService.YetkiErisimKaydet(_mapper.Map<YetkiErisimDTO>(yeniYetkiErisim));
                }
                return RedirectToAction("_AdminYetkilerIndex");
            }
            return View();
        }
    }
}
