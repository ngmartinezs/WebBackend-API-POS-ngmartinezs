using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackend_API_POS_ngmartinezs.Models
{
    public class Producto : EntityRepository
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal  valorUnitario { get; set; }
    }
}
