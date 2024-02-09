using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Repository;
using System.Reflection;

namespace MobilyaETicaret.WEB_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDistributedMemoryCache(); // Session için hafýza cache'i
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmý süresi
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddProjectServices(builder.Configuration);
            //builder.Services.AddHttpClient();

            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapAreaControllerRoute(
              name: "AdminDefaultRoute",
               areaName: "AdminPanel",
               pattern: "AdminPanel/{controller=_AdminAnasayfa}/{action=_AdminAnasayfaIndex}/{id?}"
              );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
