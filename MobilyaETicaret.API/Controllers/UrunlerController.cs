using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : BaseController
    {
        private readonly IService<Urunler> _service;
        private readonly IMapper _mapper;

        public UrunlerController(IService<Urunler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> UrunlerIndex()
        {
            var urunler = await _service.GetAllAsyncs();
            var urunlerDTO = _mapper.Map<List<UrunlerDTO>>(urunler);
            return ResultAPI(urunlerDTO);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AdresEkle(UrunEkleDTO urunEkleDTO)
        {
            var urunSave = await _service.AddAsync(_mapper.Map<Urunler>(urunEkleDTO));
            var mapAdd = _mapper.Map<UrunEkleDTO>(urunSave);
            return Ok(mapAdd);
        }

        [HttpPut]
        public async Task<IActionResult> UrunlerUpdate(UrunGuncelleDTO urunGuncelleDTO)
        {
            var getUrun = await _service.GetByIdAsync(urunGuncelleDTO.Id);
            if (getUrun != null)
            {
                await _service.UpdateAsync(_mapper.Map(urunGuncelleDTO, getUrun));
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(urunGuncelleDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var urun = await _service.GetByIdAsync(id);
            var urunDto = _mapper.Map<UrunlerDTO>(urun);
            return Ok(urunDto);
        }

    }
}
