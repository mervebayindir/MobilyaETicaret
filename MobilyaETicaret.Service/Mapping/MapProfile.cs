using AutoMapper;
using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
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
            CreateMap<Adresler, AdreslerDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriGuncelleDTO>().ReverseMap();

        }
    }
}
