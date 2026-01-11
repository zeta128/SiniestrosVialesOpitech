using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SiniestrosVialesOpitech.Domain.Options;
using System.Reflection;

namespace SiniestrosVialesOpitech.Infraestructure.Persistence
{
    public class SiniestrosVialesWriteContext : DbContext
    {
        private readonly AppSettings _appSettingsOptions;

        public SiniestrosVialesWriteContext(IOptionsSnapshot<AppSettings> options)
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

