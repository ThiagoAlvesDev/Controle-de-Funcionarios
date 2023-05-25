using ControleDeFuncionarios.APIservice;
using ControleDeFuncionarios.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFuncionarios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddControllers();
            //services.AddDbContext<BancoContext>();
            //services.AddEntityFrameworkSqlite()
            //    .AddDbContext<BancoContext>(
            //    x => x.UseSqlite(Configuration.GetConnectionString("DataBaseSQLite")));
            //services.AddScoped<IColaboradorRepositorio, ColaboradorRepositorio>();
            //services.AddDbContext<BancoContext>(x => x.UseSqlite(Configuration.GetConnectionString("DataBaseSQLite")));
            services.AddDbContext<BancoContext>(opcoes => opcoes.UseSqlite(Configuration.GetConnectionString("DataBaseSQLite")));
            services.AddHttpClient<ValidacaoCNPJ>(client =>
            {
                client.BaseAddress = new Uri("https://www.receitaws.com.br/v1/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                     })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                 })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddTransient<ValidacaoCNPJ>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
