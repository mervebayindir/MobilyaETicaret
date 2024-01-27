using AutoMapper;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Service.Services
{
    public class MenulerService : Service<Menuler>, IMenulerService
    {
        private readonly IMenulerRepository _menulerRepository;
        private readonly IMapper _mapper;
        public MenulerService(IUnitOfWork unitOfWork, IGenericRepository<Menuler> genericRepository, IMenulerRepository menulerRepository, IMapper mapper) : base(unitOfWork, genericRepository)
        {
            _menulerRepository = menulerRepository;
            _mapper = mapper;
        }

        public async Task<Menuler> AdresSilAsync(int id)
        {
            var menuGetir = await _menulerRepository.GetByIdAsync(id);
            if (menuGetir != null)
            {
                return await _menulerRepository.AdresSilAsync(menuGetir.Id);
            }
            return null;
        }

        public async Task<bool> ErisimAlaniVarmi(int? erisimAlanlariId, int? haricMenuId = null)
        {
            return await _menulerRepository.ErisimAlaniVarmi(erisimAlanlariId, haricMenuId);
        }

        public async Task<IEnumerable<MenulerVeErisimAlaniDTO>> MenulerVeErisimAlanlariAsync()
        {
            var menuVeErisimAlani = await _menulerRepository.MenulerVeErisimAlanlariAsync();
            var menuVeErisimAlanDTO = _mapper.Map<List<MenulerVeErisimAlaniDTO>>(menuVeErisimAlani);
            return menuVeErisimAlanDTO;
        }

        public async Task<MenulerVeErisimAlaniDTO> MenulerVeErisimAlanlariAsync(int id)
        {
            var menuVeErisimAlani = await _menulerRepository.MenulerVeErisimAlanlariAsync(id);
            var menuVeErisimAlanDTO = _mapper.Map<MenulerVeErisimAlaniDTO>(menuVeErisimAlani);
            return menuVeErisimAlanDTO;
        }
    }
}
