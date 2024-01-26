using MobilyaETicaret.Core.DTO;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Repository.Repositories;
using MobilyaETicaret.Repository.UnitOfWork;
using MobilyaETicaret.Service.Mapping;
using MobilyaETicaret.Service.Services;

namespace MobilyaETicaret.Web
{
    public static class DependencyInjection
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            #region API SERVİCE
            services.AddScoped<IService<Kategoriler>, KategorilerService>();
            services.AddScoped<IService<Adresler>, AdreslerService>();
            services.AddScoped<IService<Urunler>, UrunlerService>();

            #endregion


            #region SERVİCES
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped(typeof( IService<>), typeof( Service<>));
            services.AddScoped<IAdreslerService, AdreslerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IilService, IlService>();
            services.AddScoped<IKategorilerService, KategorilerService>();
            services.AddScoped<IKategoriFotograflariService, KategoriFotograflariService>();
            services.AddScoped<IUrunlerService, UrunlerService>();
            services.AddScoped<IMusterilerService, MusterilerService>();

            #endregion



            #region REPOSİTORY

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAdreslerRepository, AdreslerRepository>();
            services.AddScoped<IilRepository, ILRepository>();
            services.AddScoped<IKategorilerRepository, KategorilerRepository>();
            services.AddScoped<IKategoriFotograflariRepository, KategoriFotograflariRepository>();
            services.AddScoped<IUrunlerRepository, UrunlerRepository>();
            services.AddScoped<IMusterilerRepository, MusterilerRepository>();

            #endregion


        }
    }
}
