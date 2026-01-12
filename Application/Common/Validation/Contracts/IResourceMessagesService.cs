namespace SiniestrosVialesOpitech.Application.Common.Validation.Contracts
{
    public interface IResourceMessagesService
    {
        string ObtenerMensaje(string prmClave);
        string FormatearMensaje(string prmClave, params object[] argumentos);
        public void EstablecerRutaRecurso(string prmRutaRecurso);
    }
}
