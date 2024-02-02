using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
	public class FotograflarRepository : GenericRepository<Fotograflar>, IFotograflarRepository
	{
		public FotograflarRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
		{
		}

        public async Task<Fotograflar> FotografPasifEtAsync(int id)
        {
            var fotografSil = await GetByIdAsync(id);
            if (fotografSil != null)
            {
                fotografSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return fotografSil;
        }

        public async Task<Fotograflar> FotografSilAsync(int id)
		{
			var fotografSil = await GetByIdAsync(id);
			if (fotografSil != null)
			{
				_appDbContext.Remove(fotografSil);
				await _appDbContext.SaveChangesAsync();
			}

			return fotografSil;
		}

		public async Task<List<Fotograflar>> FotografVeUrunGetir()
		{
			return await _appDbContext.Fotograflar.Include(f => f.Urunler).ToListAsync();
		}

		public async Task<Fotograflar> FotografVeUrunGetir(int fotografId)
		{
			return await GetAllQuery(f => f.Id == fotografId).Include(f => f.Urunler).FirstOrDefaultAsync();
		}
	}
}
