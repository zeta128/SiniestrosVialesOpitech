using SiniestrosVialesOpitech.Application.Common.Validation.Contracts;

using System.Resources;

namespace SiniestrosVialesOpitech.Application.Common.Validation
{
    public class ResourceMessagesService : IResourceMessagesService
    {
        private ResourceManager _resourceManager;

        public void EstablecerRutaRecurso(string rutaRecurso)
        {
            _resourceManager = new ResourceManager(rutaRecurso, typeof(ResourceMessagesService).Assembly);
        }

        public string ObtenerMensaje(string clave)
        {
            return _resourceManager.GetString(clave) ?? "";
        }

        public string FormatearMensaje(string clave, params object[] argumentos)
        {
            return string.Format(ObtenerMensaje(clave), argumentos);
        }
    }
}
