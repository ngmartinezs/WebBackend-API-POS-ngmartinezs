using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public interface FacturaVentaServiceInterface
    {

        public  Task<RespuestaApiDto> FindAllFacturaVenta();

        public  Task<RespuestaApiDto> FindFacturaVentaById(int id);
        public  Task<RespuestaApiDto> UpdateFacturaVenta(int id, FacturaVenta facturaVenta);

        public  Task<RespuestaApiDto> CreateFacturaVenta(FacturaVenta facturaVenta);

        public  Task<RespuestaApiDto> RemoveFacturaVenta(int id);
    }
}
