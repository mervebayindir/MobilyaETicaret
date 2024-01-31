using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdreslerController : BaseController
    {
        private readonly IService<Adresler> _service;
        private readonly IMapper _mapper;

        public AdreslerController(IService<Adresler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Adresler()
        {
            var adres = await _service.GetAllAsyncs();
            var adresDto = _mapper.Map<List<AdreslerDTO>>(adres);
            return ResultAPI(adresDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AdresEkle(AdresEkleDTO adresEkle)
        {
            var adresSave = await _service.AddAsync(_mapper.Map<Adresler>(adresEkle));
            var mapAdd = _mapper.Map<AdresEkleDTO>(adresSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> AdresGuncelle(int id, AdresGuncelleDTO updateDTO)
        {
            var adresGetir = await _service.GetByIdAsync(id);
            if (adresGetir != null)
            {
                _mapper.Map(updateDTO, adresGetir);

                await _service.UpdateAsync(adresGetir);
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(updateDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var adres = await _service.GetByIdAsync(id);
            var adresDto = _mapper.Map<AdresGuncelleDTO>(adres);
            return Ok(adresDto);
        }
    }
}
