using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.IServices;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SiparislerController : BaseController
    {
        private readonly ISiparislerService _siparislerService;

        public SiparislerController(ISiparislerService siparislerService)
        {
            _siparislerService = siparislerService;
        }

        [HttpGet]
        public async Task<IActionResult> Siparisler()
        {
            var siparisBilgileri = await _siparislerService.SiparisDetaylarGetirAsync();
            return ResultAPI(siparisBilgileri);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> SiparislerGetir(int SiparisId)
        {
            var siparisBilgileri = await _siparislerService.SiparisDetaylarGetirAsync(SiparisId);
            return ResultAPI(siparisBilgileri);
        }
    }
}
