using Carter;
using FluentValidation;
using Microsoft.Extensions.Options;
using SiniestrosVialesOpitech.Application.Common.Validation;
using SiniestrosVialesOpitech.Application.Common.Validation.Contracts;
using SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries;
using SiniestrosVialesOpitech.Domain.Options;
using SiniestrosVialesOpitech.Infraestructure;
using SiniestrosVialesOpitech.Infraestructure.Persistence;
using SiniestrosVialesOpitech.Infraestructure.Repositories;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;
using System.Reflection;



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

            
            services.AddScoped<IResourceMessagesService, ResourceMessagesService>();

            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISiniestroVialRepository, SiniestroVialRepository>();
            services.AddScoped<ISiniestroVictimaRepository, SiniestroVictimaRepository>();
            services.AddScoped<ISiniestroVehiculoRepository, SiniestroVehiculoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<ITipoSiniestroRepository, TipoSiniestroRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IVictimaRepository, VictimaRepository>();
            #endregion

            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            services.AddCarter();
            
            services.AddHttpClient();
            services.AddHealthChecks();
            services.AddAuthorization();
            return services;
        }


        public static IServiceCollection AddSiniestrosExceptionServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddSiniestrosExceptionServices(this IServiceCollection services) =>
            AddSiniestrosExceptionServices(services, Assembly.GetExecutingAssembly());

       
    }
}
