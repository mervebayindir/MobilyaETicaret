            
using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Repository;
using MobilyaETicaret.Web;
using System.Reflection;

namespace MobilyaETicaret.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocument();
            builder.Services.AddProjectServices();

            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });

            var app = builder.Build();

            app.UseOpenApi();
            app.UseSwaggerUi();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
