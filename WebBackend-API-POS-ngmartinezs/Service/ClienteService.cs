using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Repository;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public class ClienteService : ClienteServiceInterface
    {
        private readonly ClienteRepositoryInterface _Repository;

        public ClienteService(ClienteRepositoryInterface repository)
        {
            this._Repository = repository;
        }

        public async Task<RespuestaApiDto> FindAllCliente()
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                IEnumerable<Cliente> lListadoCliente= (IEnumerable<Cliente>)await this._Repository.getAll();
                lRespuestaApiDto.codigoError = Util.COD_FINDED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_FINDED_OK;
                lRespuestaApiDto.listadoCliente = lListadoCliente;
            }
            catch (Exception exception)
            {

                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO + exception.StackTrace;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> FindClienteById(int id)
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Producto lProducto = (Producto)await this._Repository.findById(id);
                lRespuestaApiDto.codigoError = Util.COD_FINDED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_FINDED_OK;
                lRespuestaApiDto.producto = lProducto;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;

        }

        public async Task<RespuestaApiDto> UpdateCliente(int id, Cliente cliente)
        {

            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Cliente lCliente = (Cliente)await this._Repository.update(id, cliente);
                lRespuestaApiDto.codigoError = Util.COD_UPDATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_UPDATED_OK;
                lRespuestaApiDto.cliente = lCliente;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> CreateCliente(Cliente cliente)
        {

            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Cliente lCliente = (Cliente)await this._Repository.save(cliente);
                lRespuestaApiDto.codigoError = Util.COD_CREATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_CREATED_OK;
                lRespuestaApiDto.cliente = lCliente;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> RemoveCliente(int id)
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Cliente lCliente = (Cliente)await this._Repository.delete(id);
                lRespuestaApiDto.codigoError = Util.COD_DELETED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_DELETED_OK;
                lRespuestaApiDto.cliente = lCliente;
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
