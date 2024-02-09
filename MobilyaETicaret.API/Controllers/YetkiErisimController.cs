using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class YetkiErisimController : BaseController
    {
        private readonly IYetkiErisimService _yetkiErisimService;
        private readonly IMapper _mapper;

        public YetkiErisimController(IYetkiErisimService yetkiErisimService, IMapper mapper)
        {
            _yetkiErisimService = yetkiErisimService;
            _mapper = mapper;
        }

        public async Task<IActionResult> YetkiErisim()
        {
            var yetkiErisim = await _yetkiErisimService.GetAllAsyncs();
            var yetkiErisimDTO = _mapper.Map<YetkiErisimDTO>(yetkiErisim);
            return View(yetkiErisimDTO);
        }

        [HttpPost, ActionName("add")]
        public async Task<IActionResult> YetkiErisimEkle(YetkiErisimDTO yetkiErisimDTO)
        {
            var yetkiErisimSave = await _yetkiErisimService.AddAsync(_mapper.Map<YetkiErisim>(yetkiErisimDTO));
            var mapAdd = _mapper.Map<YetkiErisimDTO>(yetkiErisimSave);
            return View(mapAdd);
        }
    }
}
