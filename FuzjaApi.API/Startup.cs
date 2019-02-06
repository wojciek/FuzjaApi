using FuzjaApi.ApplicationService.Cars;
using FuzjaApi.ApplicationService.Persons;
using FuzjaApi.Domain.Persons;
using FuzjaApi.Domain.UnitOfWork;
using FuzjaApi.Infrastructure;
using FuzjaApi.Infrastructure.Domain;
using FuzjaApi.Infrastructure.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuzjaApi.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            var connection = @"Server=IT-084\TECHNIKA;Database=fuzja_webapi;User ID=admin;Password=admin;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<FuzjaApiDbContext>(options => options.UseSqlServer(connection));

            RegisterDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(b => b.WithOrigins(Configuration["AppUrls:ClientUrl"]).AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyOrigin());
            app.UseMvc();
        }

        private static void RegisterDependencies(IServiceCollection services) // kontener powiązań Dependency Injection
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<GetPersonsUseCase, GetPersonsUseCase>();
            services.AddTransient<IPersonsQuery, PersonsQuery>();
            services.AddTransient<GetAvailableCarsUseCase, GetAvailableCarsUseCase>();
            services.AddTransient<IAvailableCarsQuery, AvailableCarsQuery>();
            services.AddTransient<GetPersonDataUseCase, GetPersonDataUseCase>();
            services.AddTransient<IPersonDataQuery, GetPersonDataQuery>();
            services.AddTransient<CreatePersonUseCase, CreatePersonUseCase>();
            services.AddTransient<IPersonRepository, PersonRepository>();

        }
    }
}
