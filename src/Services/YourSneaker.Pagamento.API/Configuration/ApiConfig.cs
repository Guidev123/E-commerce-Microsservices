using Microsoft.EntityFrameworkCore;
using YourSneaker.Pagamento.API.Data;
using YourSneaker.Pagamento.API.Facade;
using YourSneaker.WebAPI.Core.Identidade;

namespace YourSneaker.Pagamento.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PagamentosContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddCors(options =>
            {
                options.AddPolicy("Total", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            services.AddControllers();

            services.Configure<PagamentoConfig>(configuration.GetSection("PagamentoConfig")); // ALIMENTANDO OS DADOS NA APP SETTINGS

            services.AddEndpointsApiExplorer();
        }
        public static void UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
