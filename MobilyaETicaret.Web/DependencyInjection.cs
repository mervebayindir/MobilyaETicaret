using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
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
            #region SERVİCES
            //services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped(typeof( IService<>), typeof( Service<>));
            services.AddScoped<IAdreslerService, AdreslerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IilService, IlService>();
            services.AddScoped<IKategorilerService, KategorilerService>();
            services.AddScoped<IKategoriFotograflariService, KategoriFotograflariService>();

            #endregion



            #region REPOSİTORY

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAdreslerRepository, AdreslerRepository>();
            services.AddScoped<IilRepository, ILRepository>();
            services.AddScoped<IKategorilerRepository, KategorilerRepository>();
            services.AddScoped<IKategoriFotograflariRepository, KategoriFotograflariRepository>();

            #endregion


        }
    }
}
