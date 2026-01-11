using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SiniestrosVialesOpitech.Domain.Options;
using System.Reflection;

namespace SiniestrosVialesOpitech.Infraestructure
{
    public class SiniestrosVialesReadContext : DbContext
    {
        private readonly AppSettings _appSettingsOptions;
    
        public SiniestrosVialesReadContext(IOptionsSnapshot<AppSettings> options)
        {
            _appSettingsOptions = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_appSettingsOptions.DefaultConnection);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}

