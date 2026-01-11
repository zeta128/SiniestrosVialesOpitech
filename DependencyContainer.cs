using Carter;
using Microsoft.Extensions.Options;
using SiniestrosVialesOpitech.Domain.Options;
using SiniestrosVialesOpitech.Infraestructure;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;



namespace SiniestrosVialesOpitech
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Program).Assembly;
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SectionKey));
            #region WriteContext

            services.AddDbContext<SiniestrosVialesWriteContext>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
                DbContextOptionSetup.ConfigureWriteOptions(options, appSettings.DefaultConnection);
            });

            #endregion

            #region ReadContext

            services.AddDbContext<SiniestrosVialesReadContext>((serviceProvider, options) =>
            {
                var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
                DbContextOptionSetup.ConfigureReadOptions(options, appSettings.DefaultConnection);
            });

            #endregion
            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            services.AddCarter();
            
            services.AddHttpClient();
            services.AddHealthChecks();
            services.AddAuthorization();
            return services;
        }
    }
}
