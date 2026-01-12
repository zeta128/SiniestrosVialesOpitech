using MediatR;
using SiniestrosVialesOpitech.Application.Common.Exceptions;
using SiniestrosVialesOpitech.Application.Common.Resources;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Application.Common.Validation.Contracts;
using SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.ValueObjects;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;
using ESiniestro = SiniestrosVialesOpitech.Domain.Entities.Siniestros;


namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Commands.Handlers
{
    public class CrearSiniestroVialCommandHandler(
        IResourceMessagesService _recourseMessagesService, 
        IUnitOfWork unitOfWork, ISiniestroVialRepository _siniestroVialRepository,
        IMunicipioRepository _municipioRepository,
        ITipoSiniestroRepository _tipoSiniestroRepository) : IRequestHandler<CrearSiniestroVialCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(CrearSiniestroVialCommand request, CancellationToken cancellationToken)
        {
            FechaSiniestro fecha;
            try
            {
                #region Validaciones
                fecha = new FechaSiniestro(request.fecha);
                await ValidarMunicipioYTipoSiniestroPorId(request.idMunicipio,request.IdTipoSiniestro);
                #endregion

                await RegistrarSiniestroVial(request);
                await unitOfWork.SaveChangesAsync();
                return new BaseResponse<bool>(true);
            }
            
            catch (DomainException ex)
            {
                _recourseMessagesService.EstablecerRutaRecurso(ResourcePaths.Errores);
                return new BaseResponse<bool>(_recourseMessagesService.FormatearMensaje(ex?.Message));
            }

            
        }

        private async Task RegistrarSiniestroVial(CrearSiniestroVialCommand request)
        {
            ESiniestro eSiniestro = default!;         
            eSiniestro = await CrearEntidadCargueSiniestroVial(request);
            await _siniestroVialRepository.CrearSiniestroVialAsync(eSiniestro);
        }
        


        private async Task<ESiniestro> CrearEntidadCargueSiniestroVial(CrearSiniestroVialCommand request)
        {           
            Siniestros nuevoSiniestro = default!;

            nuevoSiniestro = ESiniestro.CrearSiniestroSimple(
                request.fecha,
                request.idMunicipio,
                request.IdTipoSiniestro,
                request.NumeroVictimas,
                request.Descripcion
               
            );
            return nuevoSiniestro;
        }

        public async Task ValidarMunicipioYTipoSiniestroPorId(int idMunicipio, int idTipoSiniestro)
        {
            bool existeMunicipio = await _municipioRepository.ExisteMunicipioPorIdAsync(idMunicipio);
            bool existeTipoSiniestro = await _tipoSiniestroRepository.ExisteTipoSiniestroPorIdAsync(idTipoSiniestro);

            if (!existeMunicipio)
            {
                throw new DomainException(MessageKeys.NoExisteMunicipioPorId);
            }

            if (!existeTipoSiniestro)
            {
                throw new DomainException(MessageKeys.NoExisteTipoSiniestroPorId);
            }

        }
    }
}
