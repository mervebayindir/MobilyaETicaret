using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;

namespace MobilyaETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenulerController : BaseController
    {
        private readonly IService<Menuler> _service;
        private readonly IMapper _mapper;

        public MenulerController(IService<Menuler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Menuler()
        {
            var menu = await _service.GetAllAsyncs();
            var menuDto = _mapper.Map<List<MenulerDTO>>(menu);
            return ResultAPI(menuDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> MenuEkle(MenuEkleDTO menuEkleDTO)
        {
            var menuSave = await _service.AddAsync(_mapper.Map<Menuler>(menuEkleDTO));
            var mapAdd = _mapper.Map<MenuEkleDTO>(menuSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> MenuGuncelle(int id, MenuGuncelleDTO menuGuncelleDTO)
        {
            var menuGetir = await _service.GetByIdAsync(id);
            if (menuGetir != null)
            {
                _mapper.Map(menuGuncelleDTO, menuGetir);

                await _service.UpdateAsync(menuGetir);
            }
            else
            {
                return NoContent();
            }
            return ResultAPI(menuGuncelleDTO);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var menu = await _service.GetByIdAsync(id);
            var menuDto = _mapper.Map<MenulerDTO>(menu);
            return Ok(menuDto);
        }

    }
}
