using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SiparisDetayController : BaseController
    {
        private readonly ISiparisDetayService _siparisDetayService;

        public SiparisDetayController(ISiparisDetayService siparisDetayService)
        {
            _siparisDetayService = siparisDetayService;
        }

        [HttpGet]
        public async Task<IActionResult> SiparisDetay(int SiparisId)
        {
            var siparisDetay = await _siparisDetayService.SiparisBilgileriGetir(SiparisId);
            return ResultAPI(siparisDetay);
        }
    }
}
