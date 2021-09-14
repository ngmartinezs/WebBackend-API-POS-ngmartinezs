using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.DTO;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public interface ProductoServiceInterface
    {
        public Task<RespuestaApiDto> FindAllProducto();

        public Task<RespuestaApiDto> FindProductoById(int id);

        public Task<RespuestaApiDto> UpdateProducto(int id, Producto producto);

        public Task<RespuestaApiDto> CreateProducto(Producto producto);

        public Task<RespuestaApiDto> RemoveProducto(int id);
    }
}
