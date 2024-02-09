using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Repository.Repositories;
using MobilyaETicaret.Repository.UnitOfWork;
using MobilyaETicaret.Service.Mapping;
using MobilyaETicaret.Service.Services;
using MobilyaETicaret.WEB_API.Areas.AdminPanel.APIService;

namespace MobilyaETicaret.WEB_API
{
    public static class DependencyInjection
    {
        public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region API SERVİCE
            services.AddScoped<IService<Kategoriler>, KategorilerService>();
            services.AddScoped<IService<Adresler>, AdreslerService>();
            services.AddScoped<IService<Urunler>, UrunlerService>();
            services.AddScoped<IService<Musteriler>, MusterilerService>();
            services.AddScoped<IService<Menuler>, MenulerService>();

            #endregion


            #region SERVİCES
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IAdreslerService, AdreslerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IilService, IlService>();
            services.AddScoped<IKategorilerService, KategorilerService>();
            services.AddScoped<IKategoriFotograflariService, KategoriFotograflariService>();
            services.AddScoped<IUrunlerService, UrunlerService>();
            services.AddScoped<IMusterilerService, MusterilerService>();
            services.AddScoped<IMenulerService, MenulerService>();
            services.AddScoped<IErisimAlanlariService, ErisimAlanlariService>();
            services.AddScoped<IFotografService, FotograflarService>();
            services.AddScoped<IYetkilerService, YetkilerService>();
            services.AddScoped<IKullanicilarService, KullanicilarService>();
            services.AddScoped<ISiparislerService, SiparislerService>();
            services.AddScoped<ISiparisDetayService, SiparisDetayService>();
            services.AddScoped<IPersonellerService, PersonellerService>();
            services.AddScoped<IYetkiErisimService, YetkiErisimService>();
            services.AddScoped<IYorumlarService, YorumlarService>();

            #endregion



            #region REPOSİTORY

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAdreslerRepository, AdreslerRepository>();
            services.AddScoped<IilRepository, ILRepository>();
            services.AddScoped<IKategorilerRepository, KategorilerRepository>();
            services.AddScoped<IKategoriFotograflariRepository, KategoriFotograflariRepository>();
            services.AddScoped<IUrunlerRepository, UrunlerRepository>();
            services.AddScoped<IMusterilerRepository, MusterilerRepository>();
            services.AddScoped<IMenulerRepository, MenulerRepository>();
            services.AddScoped<IErisimAlanlariRepository, ErisimAlanlariRepository>();
            services.AddScoped<IFotograflarRepository, FotograflarRepository>();
            services.AddScoped<IKullanicilarRepository, KullaniciRepository>();
            services.AddScoped<IYetkilerRepository, YetkilerRepository>();
            services.AddScoped<ISiparislerRepository, SiparislerRepository>();
            services.AddScoped<ISiparisDetayRepository, SiparisDetayRepository>();
            services.AddScoped<IPersonellerRepository, PersonellerRepository>();
            services.AddScoped<IYetkiErisimRepository, YetkiErisimRepository>();
            services.AddScoped<IYorumlarRepository, YorumlarRepository>();

            #endregion

            AddHttpClients(services, configuration);
        }

        private static void AddHttpClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<UrunlerAPIService>(ops =>
            {
                ops.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.AddHttpClient<KategorilerAPIService>(ops =>
            {
                ops.BaseAddress = new Uri(configuration["BaseUrl"]);
            });
            services.AddHttpClient<KullanicilarAPİService>(ops =>
            {
                ops.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

        }
    }
}
