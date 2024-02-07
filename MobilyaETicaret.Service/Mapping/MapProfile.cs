using AutoMapper;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Core.SP_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Adresler, AdresGuncelleDTO>().ReverseMap();
            CreateMap<Adresler, AdresEkleDTO>().ReverseMap();
            CreateMap<Adresler, AdreslerDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriGuncelleDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriFotografDTO>().ReverseMap();
            CreateMap<Kategoriler, KategorilerDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriEkleDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriFotografGosterDTO>().ReverseMap();
            CreateMap<Urunler, UrunlerveKategoriDTO>().ReverseMap();
            CreateMap<Urunler, UrunlerDTO>().ReverseMap();
            CreateMap<Urunler, UrunEkleDTO>().ReverseMap();
            CreateMap<Urunler, UrunGuncelleDTO>().ReverseMap();
            CreateMap<Musteriler, MusterilerDTO>().ReverseMap();
            CreateMap<Musteriler, MusteriEkleDTO>().ReverseMap();
            CreateMap<Menuler, MenulerVeErisimAlaniDTO>().ReverseMap();
            CreateMap<Menuler, MenulerDTO>().ReverseMap();
            CreateMap<Menuler, MenuGuncelleDTO>().ReverseMap();
            CreateMap<Menuler, MenuEkleDTO>().ReverseMap();
            CreateMap<Fotograflar, FotograflarVeUrunlerDTO>().ReverseMap();
            CreateMap<Fotograflar, FotograflarDTO>().ReverseMap();
            CreateMap<Urunler, UrunModelDTO>().ReverseMap();
            CreateMap<Yetkiler, YetkilerDTO>().ReverseMap();
            CreateMap<Yetkiler, YetkiEkleDTO>().ReverseMap();
            CreateMap<Kullanicilar, KullanicilarVeYetkilerDTO>().ReverseMap();
            CreateMap<Kullanicilar, KullanicilarDTO>().ReverseMap();
            CreateMap<Kullanicilar, KullaniciEkleDTO>().ReverseMap();
            CreateMap<Siparisler, SiparislerDTO>().ReverseMap();
            CreateMap<ErisimAlanlari, ErisimAlanlariGuncelleDTO>().ReverseMap();
            CreateMap<Personeller, PersonelGuncelleDTO>().ReverseMap();



        }
    }
}
