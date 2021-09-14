using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Repository
{
    public class FacturaVentaRepository : FacturaVentaRepositoryInterface
    {
        private readonly WebBackendAPIPOSngmartinezsContext _context;

        public FacturaVentaRepository(WebBackendAPIPOSngmartinezsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<EntityRepository>> getAll() {

            IEnumerable<FacturaVenta> facturas = await _context.FacturaVenta.ToListAsync();

            foreach (FacturaVenta facturaInd in facturas)
            {
                var lCliente = await _context.Clientes.FindAsync(facturaInd.clienteId);
                facturaInd.cliente = new Cliente();
                facturaInd.cliente.id = lCliente.id;
                facturaInd.cliente.numeroId = lCliente.numeroId;
                facturaInd.cliente.tipoId = lCliente.tipoId;
                facturaInd.cliente.nombre = lCliente.nombre;
                facturaInd.cliente.apellido = lCliente.apellido;
                facturaInd.cliente.telefono = lCliente.telefono;

                facturaInd.detallesFacturaVenta = _context.DetalleFacturaVenta.Where(d => d.facturaVentaId == facturaInd.id).ToList<DetalleFacturaVenta>();


            }

            return facturas;
        }

        public async Task<EntityRepository> findById(int id)
        {
            var facturaVenta = await _context.FacturaVenta.FindAsync(id);

            if(facturaVenta != null)
            {
                var lCliente = await _context.Clientes.FindAsync(facturaVenta.clienteId);
                facturaVenta.cliente = new Cliente();
                facturaVenta.cliente.id = lCliente.id;
                facturaVenta.cliente.numeroId = lCliente.numeroId;
                facturaVenta.cliente.tipoId = lCliente.tipoId;
                facturaVenta.cliente.nombre = lCliente.nombre;
                facturaVenta.cliente.telefono = lCliente.telefono;

                facturaVenta.detallesFacturaVenta = _context.DetalleFacturaVenta.Where(d => d.facturaVentaId == facturaVenta.id).ToList<DetalleFacturaVenta>();
            }

            return facturaVenta;
        }

        public async Task<EntityRepository> update(int id, EntityRepository entity)
        {

            try
            {
                FacturaVenta facturaVenta = (FacturaVenta)entity;
                if (FacturaVentaExists(id))
                {
                    _context.Entry(facturaVenta).State = EntityState.Modified;
                    if (facturaVenta.detallesFacturaVenta != null && facturaVenta.detallesFacturaVenta.Count > 0)
                    {
                        facturaVenta.detallesFacturaVenta.ForEach(detalle => {
                            if (detalle.facturaVentaId == id)
                            {
                                _context.DetalleFacturaVenta.Update(detalle);
                            }
                                
                        });
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }

            return entity;

        }

        public async Task<EntityRepository> save(EntityRepository entity)
        {
       
            try
            {
                FacturaVenta facturaVenta = (FacturaVenta)entity;
                this._context.FacturaVenta.Add(facturaVenta);
        

                if (facturaVenta.detallesFacturaVenta != null && facturaVenta.detallesFacturaVenta.Count > 0)
                {
                    facturaVenta.detallesFacturaVenta.ForEach(detalle => {
                             detalle.facturaVentaId = facturaVenta.id;
                            _context.DetalleFacturaVenta.Add(detalle);
                    });
                    await this._context.SaveChangesAsync();
                }



                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EntityRepository> delete(int id) {

            var facturaVenta = await _context.FacturaVenta.FindAsync(id);
            if (facturaVenta != null)
            {
                if (facturaVenta.detallesFacturaVenta != null && facturaVenta.detallesFacturaVenta.Count > 0)
                {
                    facturaVenta.detallesFacturaVenta.ForEach(detalle => {
                            _context.DetalleFacturaVenta.Remove(detalle);
                    });
                }

                _context.FacturaVenta.Remove(facturaVenta);
                await _context.SaveChangesAsync();
            }
            else {
                return null;
            }

            return facturaVenta;
        }


        private bool FacturaVentaExists(int id)
        {
            return _context.FacturaVenta.Any(e => e.id == id);
        }

    }
}
