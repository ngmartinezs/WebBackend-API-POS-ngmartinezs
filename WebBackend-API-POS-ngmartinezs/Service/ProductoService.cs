using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Repository;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public class ProductoService : ProductoServiceInterface
    {
        private readonly ProductoRepositoryInterface _Repository;

        public ProductoService(ProductoRepositoryInterface repository)
        {
            this._Repository = repository;
        }

        public async Task<RespuestaApiDto> FindAllProducto()
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                IEnumerable<Producto> lListadoProducto = (IEnumerable<Producto>)await this._Repository.getAll();
                lRespuestaApiDto.codigoError = Util.COD_FINDED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_FINDED_OK;
                lRespuestaApiDto.listadoProducto = lListadoProducto;
            }
            catch (Exception exception)
            {

                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO + exception.StackTrace;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> FindProductoById(int id)
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

        public async Task<RespuestaApiDto> UpdateProducto(int id, Producto producto)
        {

            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Producto lProducto = (Producto)await this._Repository.update(id, producto);
                lRespuestaApiDto.codigoError = Util.COD_UPDATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_UPDATED_OK;
                lRespuestaApiDto.producto = lProducto;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;
        }

        public async Task<RespuestaApiDto> CreateProducto(Producto producto)
        {

            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Producto lProducto = (Producto)await this._Repository.save(producto);
                lRespuestaApiDto.codigoError = Util.COD_CREATED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_CREATED_OK;
                lRespuestaApiDto.producto = lProducto;
            }
            catch (Exception)
            {
                lRespuestaApiDto.codigoError = Util.COD_ERROR_INTERNO;
                lRespuestaApiDto.mensajeError = Util.ERROR_SERVICIO;
            }

            return lRespuestaApiDto;

        }

        public async Task<RespuestaApiDto> RemoveProducto(int id)
        {
            RespuestaApiDto lRespuestaApiDto = new RespuestaApiDto();
            lRespuestaApiDto.transactionId = Util.generateRandom();

            try
            {
                Producto lProducto = (Producto)await this._Repository.delete(id);
                lRespuestaApiDto.codigoError = Util.COD_DELETED_OK;
                lRespuestaApiDto.mensajeError = Util.MSG_DELETED_OK;
                lRespuestaApiDto.producto = lProducto;
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
