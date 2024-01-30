using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
	public class KullaniciRepository : GenericRepository<Kullanicilar>, IKullanicilarRepository
	{
		public KullaniciRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
		{
		}

		public async Task<Kullanicilar> KullaniciSilAsync(int id)
		{
			var kullaniciSil = await GetByIdAsync(id);
			if (kullaniciSil != null)
			{
				kullaniciSil.AktifMi = false;
				await _appDbContext.SaveChangesAsync();
			}
			return kullaniciSil;
		}

		public async Task<List<Kullanicilar>> KullaniciVeYetkiGetirAsync()
		{
			return await _appDbContext.Kullanicilar.Include(k => k.Yetkiler).ToListAsync();
		}

		public async Task<Kullanicilar> KullaniciVeYetkiGetirAsync(int kullanicilarId)
		{
			return await _appDbContext.Kullanicilar.Where(k => k.Id == kullanicilarId).Include(k => k.Yetkiler).FirstOrDefaultAsync();
		}
	}
}
