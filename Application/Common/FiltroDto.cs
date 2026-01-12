using System.Text.Json.Serialization;

namespace SiniestrosVialesOpitech.Application.Common
{
    public class FiltroDto
    {
        [JsonPropertyName("text")]
        public string CampoFiltrar { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string ValorFiltrar { get; set; } = string.Empty;

        [JsonIgnore]
        public bool? Seleccionado { get; set; } = false;

        [JsonIgnore]
        public object ObjetoFiltrar { get; private set; } = null!;

        public void setObjetoFiltrar(object Obj) { 
            ObjetoFiltrar = Obj;
        }


    }
}
