using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Repository.Repositories
{
    public class MenulerRepository : GenericRepository<Menuler>, IMenulerRepository
    {
        public MenulerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Menuler> AdresSilAsync(int id)
        {
            var menuSil = await GetByIdAsync(id);
            if (menuSil != null)
            {
                menuSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return menuSil;
        }

        public async Task<List<Menuler>> MenulerVeErisimAlanlariAsync()
        {
            return await _appDbContext.Menular.Include(k => k.ErisimAlanlari).ToListAsync();
        }

        public async Task<Menuler> MenulerVeErisimAlanlariAsync(int id)
        {
            return await GetAllQuery(m => m.Id == id).Include(m => m.ErisimAlanlari).FirstOrDefaultAsync();
        }
    }
}
