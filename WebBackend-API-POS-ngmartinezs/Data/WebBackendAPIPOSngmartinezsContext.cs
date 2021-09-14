using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Data
{
    public class WebBackendAPIPOSngmartinezsContext : DbContext
    {
        public WebBackendAPIPOSngmartinezsContext (DbContextOptions<WebBackendAPIPOSngmartinezsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }

        public DbSet<WebBackend_API_POS_ngmartinezs.Models.Producto> Productos { get; set; }

        public DbSet<WebBackendAPIPOSngmartinezs.Models.Cliente> Clientes { get; set; }

        public DbSet<WebBackendAPIPOSngmartinezs.Models.FacturaVenta> FacturaVenta { get; set; }

        public DbSet<WebBackendAPIPOSngmartinezs.Models.DetalleFacturaVenta> DetalleFacturaVenta { get; set; }

    }
}
