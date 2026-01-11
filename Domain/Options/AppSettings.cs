namespace SiniestrosVialesOpitech.Domain.Options;

    public class AppSettings
    {
        public const string SectionKey = "SINIESTROS_VIALES_OPITECH_CONNECTIONSTRING";
        public required string DefaultConnection {  get; set; } 
    }

