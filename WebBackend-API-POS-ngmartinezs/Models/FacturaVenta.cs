using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackendAPIPOSngmartinezs.Models
{
    public class FacturaVenta : EntityRepository
    {
        public int id { get; set; }

        public decimal valorTotal { get; set; }

        public int  clienteId {get;set;}

        public  Cliente cliente { get; set; }

        public List<DetalleFacturaVenta> detallesFacturaVenta { get; set; }
    }
}
