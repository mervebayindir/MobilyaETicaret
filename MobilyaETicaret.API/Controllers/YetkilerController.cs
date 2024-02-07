using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class YetkilerController : BaseController
    {
        private readonly IYetkilerService _yetkilerService;
        private readonly IMapper _mapper;

        public YetkilerController(IYetkilerService yetkilerService, IMapper mapper)
        {
            _yetkilerService = yetkilerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Yetkiler()
        {
            var yetkiler = await _yetkilerService.GetAllAsyncs();
            var yetkiDto = _mapper.Map<List<YetkilerDTO>>(yetkiler);
            return ResultAPI(yetkiDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> YetkiEkle(YetkiEkleDTO yetkiEkleDTO)
        {
            var yetkiSave = await _yetkilerService.AddAsync(_mapper.Map<Yetkiler>(yetkiEkleDTO));
            var mapAdd = _mapper.Map<YetkiEkleDTO>(yetkiSave);
            return ResultAPI(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> YetkiGuncelle(int id, YetkiGuncelleDTO yetkiGuncelleDTO)
        {
            var yetkiGetir = await _yetkilerService.GetByIdAsync(id);
            if (yetkiGetir != null)
            {
                _mapper.Map(yetkiGuncelleDTO, yetkiGetir);
                await _yetkilerService.UpdateAsync(yetkiGetir);
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(yetkiGuncelleDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var yetki = await _yetkilerService.GetByIdAsync(id);
            var yetkiDto = _mapper.Map<YetkiGuncelleDTO>(yetki);
            return Ok(yetkiDto);
        }
    }
}
