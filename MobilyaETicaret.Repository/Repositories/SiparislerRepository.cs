﻿using Microsoft.EntityFrameworkCore;
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
    public class SiparislerRepository : GenericRepository<Siparisler>, ISiparislerRepository
    {
        public SiparislerRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<Siparisler> SiparisSilAsync(int id)
        {
            var siparisSil = await GetByIdAsync(id);
            if (siparisSil != null)
            {
                siparisSil.AktifMi = false;
                await _appDbContext.SaveChangesAsync();
            }

            return siparisSil;
        }

        public async Task<List<Siparisler>> SiparisVeMusteriGetirAsync(int musteriId)
        {
            var siparisler = await _appDbContext.Siparisler.Include(s => s.Odemeler).Include(s => s.Musteriler).Where(s => s.MusteriId == musteriId).ToListAsync();
            return siparisler;
        }

        public async Task<List<Siparisler>> SiparisDetaylarGetirAsync()
        {
            var siparisVeMusteri = await _appDbContext.Siparisler.Include(k => k.Musteriler).Include(k=>k.Odemeler).Include(k=>k.Adresler).Include(k=>k.SiparisDetay).ToListAsync();
            return siparisVeMusteri;
        }

        public async Task<List<Siparisler>> SiparisVeMusteriGetirAsync()
        {
            var siparisVeMusteri = await _appDbContext.Siparisler.Include(k => k.Musteriler).Include(k => k.Odemeler).ToListAsync();
            return siparisVeMusteri;
        }

        public async Task<List<Siparisler>> SiparisDetaylarGetirAsync(int siparisId)
        {
            return await _appDbContext.Siparisler.Where(s => s.Id == siparisId).Include(s => s.Musteriler).Include(s => s.Odemeler).Include(k => k.SiparisDetay).ToListAsync();
        }
    }
}
