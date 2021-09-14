using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.DTO
{
    public class RespuestaApiDto
    {
        public string transactionId { set; get; }
        public int codigoError { set; get; } 
        public string mensajeError { set; get; }

        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Cliente cliente { set; get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Cliente> listadoCliente { set; get; }



        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Producto producto { set; get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Producto> listadoProducto { set; get; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FacturaVenta facturaVenta { set; get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<FacturaVenta> listadoFacturaVenta { set; get; }

    }
}
