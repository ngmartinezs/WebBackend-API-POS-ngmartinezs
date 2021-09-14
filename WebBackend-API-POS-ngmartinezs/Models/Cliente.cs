using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackendAPIPOSngmartinezs.Models
{
    public class Cliente : EntityRepository
    {
        public int id { get; set; }
        public string tipoId { get; set; }

        public string numeroId { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string telefono { get; set; }

    }
}
