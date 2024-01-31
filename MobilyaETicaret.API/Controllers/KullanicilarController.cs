using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class KullanicilarController : BaseController
    {
        private readonly IService<Kullanicilar> _service;
        private readonly IMapper _mapper;

        public KullanicilarController(IService<Kullanicilar> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> KullanicilarIndex()
        {
            var kullanici = await _service.GetAllAsyncs();
            var kullaniciDTO = _mapper.Map<List<KullanicilarDTO>>(kullanici);
            return ResultAPI(kullaniciDTO);
        }

        [HttpPost("add")]
        public async Task<IActionResult> KullaniciEkle(KullaniciEkleDTO kullaniciEkleDTO)
        {
            var kullaniciSave = await _service.AddAsync(_mapper.Map<Kullanicilar>(kullaniciEkleDTO));
            var mapAdd = _mapper.Map<KullaniciEkleDTO>(kullaniciSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> KullaniciGuncelle(int id, KullaniciEkleDTO kullaniciGuncelleDTO)
        {
            var kullaniciGetir = await _service.GetByIdAsync(id);
            if (kullaniciGetir != null)
            {
                await _service.UpdateAsync(_mapper.Map(kullaniciGuncelleDTO, kullaniciGetir));
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(kullaniciGuncelleDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var kullanici = await _service.GetByIdAsync(id);
            var kullaniciDto = _mapper.Map<KullanicilarDTO>(kullanici);
            return Ok(kullaniciDto);
        }
    }
}
