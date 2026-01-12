using Azure.Core;
using MediatR;
using SiniestrosVialesOpitech.Application.Common.Exceptions;
using SiniestrosVialesOpitech.Application.Common.Resources;
using SiniestrosVialesOpitech.Application.Common.Responses;
using SiniestrosVialesOpitech.Application.Common.Validation.Contracts;
using SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Queries;
using SiniestrosVialesOpitech.Domain.DTOs;
using SiniestrosVialesOpitech.Domain.Entities;
using SiniestrosVialesOpitech.Domain.ValueObjects;
using SiniestrosVialesOpitech.Infraestructure.Repositories.Contracts;
using ESiniestro = SiniestrosVialesOpitech.Domain.Entities.Siniestros;
using EVehiculo = SiniestrosVialesOpitech.Domain.Entities.Vehiculos;
using EVictima = SiniestrosVialesOpitech.Domain.Entities.Victimas;


namespace SiniestrosVialesOpitech.Application.Features.SiniestrosViales.V1.Commands.Handlers
{
    public class CrearSiniestroVialCommandHandler(
        IResourceMessagesService _recourseMessagesService,
        IUnitOfWork unitOfWork, 
        ISiniestroVialRepository _siniestroVialRepository,
        ISiniestroVehiculoRepository _siniestroVehiculoRepository,
        ISiniestroVictimaRepository _siniestroVictimaRepository,
        IMunicipioRepository _municipioRepository,
        ITipoSiniestroRepository _tipoSiniestroRepository,
        IVehiculoRepository _vehiculoRepository,
        IVictimaRepository _victimaRepository

        ) : IRequestHandler<CrearSiniestroVialCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(CrearSiniestroVialCommand request, CancellationToken cancellationToken)
        {
            FechaSiniestro fecha;
            try
            {
                #region Validaciones
                fecha = new FechaSiniestro(request.fecha);
                await ValidarMunicipioYTipoSiniestroPorId(request.idMunicipio, request.IdTipoSiniestro);
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

            if (request.Vehiculos != null)
            {
                await RegistrarVehiculos(request.Vehiculos, eSiniestro);
            }
            
        }
        private async Task RegistrarVehiculos(List<VehiculoDTO> vehiculosDTO, ESiniestro eSiniestro)
        {
            List<EVehiculo> eVehiculos = default!;
            var vehiculosConRol = await CrearEntidadesCargueVehiculos(vehiculosDTO);

            eVehiculos = vehiculosConRol
            .Select(v => v.Vehiculo)
            .ToList();

            await _vehiculoRepository.CrearVehiculosAsync(eVehiculos);

            List<SiniestrosVehiculos> siniestrosVehiculos = new List<SiniestrosVehiculos>();
            foreach (var vehiculoConRol in vehiculosConRol)
            {
                siniestrosVehiculos.Add(new SiniestrosVehiculos()
                {
                    SiniestroNavigation = eSiniestro,
                    VehiculoNavigation = vehiculoConRol.Vehiculo,
                    RolVehiculo = vehiculoConRol.RolVehiculo
                });
            }
            await _siniestroVehiculoRepository.CrearSiniestrosVehiculosAsync(siniestrosVehiculos);

        }

        //private async Task RegistrarVictimas(List<VictimaDTO> victimasDTO, ESiniestro eSiniestro)
        //{
        //    List<EVictima> eVictimas = default!;
        //    var victimasConRol = await CrearEntidadesCargueVictimas(victimasDTO);

        //    eVictimas = victimasConRol
        //    .Select(v => v.Victima)
        //    .ToList();

        //    await _victimaRepository.CrearVictimasAsync(eVictimas);

        //    List<SiniestrosVictimas> siniestrosVictimas = new List<SiniestrosVictimas>();
        //    foreach (var victimaConRol in victimasConRol)
        //    {
        //        siniestrosVictimas.Add(new SiniestrosVictimas()
        //        {
        //            SiniestroNavigation = eSiniestro,
        //            VictimaNavigation = victimaConRol.Victima,
        //            RolVictima = victimaConRol.RolVictima
        //        });
        //    }
        //    await _siniestroVehiculoRepository.CrearSiniestrosVehiculosAsync(siniestrosVictimas);

        //}



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


        private Task<List<(EVehiculo Vehiculo, string RolVehiculo)>> CrearEntidadesCargueVehiculos(List<VehiculoDTO> vehiculosDTO)
        {
            var nuevosVehiculos = vehiculosDTO
                .Select(vehiculo => (
                    Vehiculo: EVehiculo.CrearVehiculo(
                        vehiculo.Placa,
                        vehiculo.TipoVehiculo,
                        vehiculo.Marca,
                        vehiculo.Modelo,
                        vehiculo.Color,
                        vehiculo.Servicio
                    ),
                    RolVehiculo: vehiculo.RolVehiculo
                ))
                .ToList();

            return Task.FromResult(nuevosVehiculos);
        }


        //private Task<List<(EVictima Victima, string RolVictima)>> CrearEntidadesCargueVictimas(List<VictimaDTO> victimasDTO)
        //{
        //    var nuevasVictimas = victimasDTO
        //        .Select(victima => (
        //            Victima: EVictima.CrearVictima(
        //                victima.TipoDocumento,
        //                victima.NumeroDocumento,
        //                victima.Nombres,
        //                victima.Apellidos,
        //                victima.Edad,
        //                victima.Sexo,
        //                victima.Condicion
        //            ),
        //            RolVictima: victima.RolVictima
        //        ))
        //        .ToList();

        //    return Task.FromResult(nuevasVictimas);
        //}

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
