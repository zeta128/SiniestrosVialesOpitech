using SiniestrosVialesOpitech.Domain.Entities;

namespace SiniestrosVialesOpitech.Domain.DTOs

{
    public class SiniestroDatosBasicosResponseDTO
    {
        public DateTime FechaSiniestro { get; set; }       
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string TipoSiniestro { get; set; }
        public int NumeroVictimas { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<VictimaDTO>? Victimas { get; set; }
        public List<VehiculoDTO>? Vehiculos { get; set; }
     

    }
}
