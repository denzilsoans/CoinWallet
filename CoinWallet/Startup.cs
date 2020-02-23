using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoinWallet.DomainModel.Repository.Contracts;
using CoinWallet.DomainModel.Repository;
using CoinWallet.DomainModel.Services.Contracts;
using CoinWallet.DomainModel.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CoinWallet.DomainModel;
using System;
using CoinWallet.Web.CustomMiddleWare;
using System.Linq;
using System.Threading;

namespace CoinWallet.Web
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
            services.AddDbContext<ApplicationDbContext>(
              options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson();

            RegisterMappings(services);
        }

        private void RegisterMappings(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletService, WalletService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Thread.Sleep(90000); //Delay to make sure sql server is up and running before migrations run

            ApplyMigrations(app);
        }

        private static void ApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
