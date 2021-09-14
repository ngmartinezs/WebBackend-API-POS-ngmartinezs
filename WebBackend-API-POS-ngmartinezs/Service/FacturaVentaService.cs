using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Repository;


namespace WebBackendAPIPOSngmartinezs.Service
{
    public class FacturaVentaService : FacturaVentaServiceInterface
    {
        private readonly FacturaVentaRepositoryInterface _Repository;

        public FacturaVentaService(FacturaVentaRepositoryInterface repository)
        {
            this._Repository = repository;
        }

        public async Task<RespuestaApiDto> FindAllFacturaVenta()
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                IEnumerable<FacturaVenta> lListadoFactura = (IEnumerable<FacturaVenta>)await this._Repository.getAll();
                lRespuestaApiDto.codigoError = Util.COD_FINDED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_FINDED_OK;
                lRespuestaApiDto.listadoFacturaVenta = lListadoFactura;
            }
            catch(Exception exception)
            {
                
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO + exception.StackTrace;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> FindFacturaVentaById(int id)
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                FacturaVenta lFacturaVenta = (FacturaVenta)await this._Repository.findById(id);
                lRespuestaApiDto.codigoError = Util.COD_FINDED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_FINDED_OK;
                lRespuestaApiDto.facturaVenta = lFacturaVenta;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;

        }

        public async Task<RespuestaApiDto> UpdateFacturaVenta(int id, FacturaVenta facturaVenta)
        {
            
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                FacturaVenta lFacturaVenta = (FacturaVenta)await this._Repository.update(id, facturaVenta);
                lRespuestaApiDto.codigoError = Util.COD_UPDATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_UPDATED_OK;
                lRespuestaApiDto.facturaVenta = lFacturaVenta;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> CreateFacturaVenta(FacturaVenta facturaVenta)
        {
            
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                FacturaVenta lFacturaVenta = (FacturaVenta)await this._Repository.save(facturaVenta);
                lRespuestaApiDto.codigoError = Util.COD_CREATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_CREATED_OK;
                lRespuestaApiDto.facturaVenta = lFacturaVenta;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;

        }

        public async Task<RespuestaApiDto> RemoveFacturaVenta(int id)
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                FacturaVenta lFacturaVenta = (FacturaVenta)await this._Repository.delete(id);
                lRespuestaApiDto.codigoError = Util.COD_DELETED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_DELETED_OK;
                lRespuestaApiDto.facturaVenta = lFacturaVenta;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;
        }
    }
}
