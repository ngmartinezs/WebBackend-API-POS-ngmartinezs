using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackendAPIPOSngmartinezs.Models
{
    public class DetalleFacturaVenta
    {
        public int id { get; set; }

        public int facturaVentaId { get; set; }

        public int productoId { get; set; }

        public int cantidad { get; set; }

        public decimal valorDetalle { get; set; }

    }
}
