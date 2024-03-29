﻿using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using MobilyaETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class SiparislerService : Service<Siparisler>, ISiparislerService
    {
        private readonly ISiparislerRepository _siparislerRepository;
        public SiparislerService(IUnitOfWork unitOfWork, IGenericRepository<Siparisler> genericRepository, ISiparislerRepository siparislerRepository) : base(unitOfWork, genericRepository)
        {
            _siparislerRepository = siparislerRepository;
        }

        public async Task<List<SiparislerDTO>> SiparisDetaylarGetirAsync()
        {
            var siparislerGetir = await _siparislerRepository.SiparisDetaylarGetirAsync();
            var siparislerDTO = siparislerGetir.Select(s => new SiparislerDTO
            {
                SiparisId = s.Id,
                AktifMi = s.AktifMi,
                EklenmeTarih = s.EklenmeTarih,
                MusteriAdiSoyadi = s.Musteriler.Adi + " " + s.Musteriler.Soyadi,
                Telefonu = s.Musteriler.Telefonu,
                OdemeTipi = s.Odemeler.OdemeTipi,
                ToplamFiyat = s.Odemeler.Siparisler.ToplamFiyat,
                ToplamUrunAdeti = s.Odemeler.Siparisler.ToplamUrunAdet,
                SiparisDetayId = s.SiparisDetay.FirstOrDefault().SiparisId,
            });
            return siparislerDTO.ToList();
        }

        public async Task<List<SiparislerDTO>> SiparisDetaylarGetirAsync(int siparisId)
        {
            var siparislerGetir = await _siparislerRepository.SiparisDetaylarGetirAsync(siparisId);
            var siparislerDTO = siparislerGetir.Select(s => new SiparislerDTO
            {
                SiparisId = s.Id,
                AktifMi = s.AktifMi,
                EklenmeTarih = s.EklenmeTarih,
                MusteriAdiSoyadi = s.Musteriler.Adi + " " + s.Musteriler.Soyadi,
                Telefonu = s.Musteriler.Telefonu,
                OdemeTipi = s.Odemeler.OdemeTipi,
                ToplamFiyat = s.Odemeler.Siparisler.ToplamFiyat,
                ToplamUrunAdeti = s.Odemeler.Siparisler.ToplamUrunAdet,
                SiparisDetayId = s.SiparisDetay.FirstOrDefault().SiparisId,
            });
            return siparislerDTO.ToList();
        }

        public async Task<Siparisler> SiparisSilAsync(int id)
        {
            var siparisGetir = await _siparislerRepository.GetByIdAsync(id);
            if (siparisGetir != null)
            {
                return await _siparislerRepository.SiparisSilAsync(siparisGetir.Id);
            }
            return null;
        }

        public async Task<List<Siparisler>> SiparisVeMusteriGetirAsync(int musteriId)
        {
            return await _siparislerRepository.SiparisVeMusteriGetirAsync(musteriId);
        }

        public async Task<List<Siparisler>> SiparisVeMusteriGetirAsync()
        {
            return await _siparislerRepository.SiparisDetaylarGetirAsync();
        }
    }
}