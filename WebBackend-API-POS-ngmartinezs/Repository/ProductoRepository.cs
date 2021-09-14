using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Repository
{
    public class ProductoRepository : ProductoRepositoryInterface
    {
        private readonly WebBackendAPIPOSngmartinezsContext _context;

        public ProductoRepository(WebBackendAPIPOSngmartinezsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<EntityRepository>> getAll()
        {
            IEnumerable<Producto> facturas = await _context.Productos.ToListAsync();

            return facturas;
        }

        public async Task<EntityRepository> findById(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);

            return Producto;
        }

        public async Task<EntityRepository> update(int id, EntityRepository entity)
        {

            try
            {
                Producto Producto = (Producto)entity;
                if (ProductoExists(id))
                {
                    _context.Entry(Producto).State = EntityState.Modified;
                  
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return entity;

        }

        public async Task<EntityRepository> save(EntityRepository entity)
        {
            try
            {
                Producto Producto = (Producto)entity;
                this._context.Productos.Add(Producto);
         
                await this._context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EntityRepository> delete(int id)
        {

            Producto lProducto = await _context.Productos.FindAsync(id);
            if (lProducto == null)
            {
                return null;
            }

            _context.Productos.Remove(lProducto);
           await  _context.SaveChangesAsync();

            return lProducto;
        }


        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.id == id);
        }
    }
}
