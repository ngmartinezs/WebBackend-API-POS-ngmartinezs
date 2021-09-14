using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackendAPIPOSngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Service;

namespace WebBackendAPIPOSngmartinezs.Repository
{
    public class ClienteRepository : ClienteRepositoryInterface
    {
        private readonly WebBackendAPIPOSngmartinezsContext _context;

        public ClienteRepository(WebBackendAPIPOSngmartinezsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<EntityRepository>> getAll()
        {
            IEnumerable<Cliente> clientes = await _context.Clientes.ToListAsync();

            return clientes;
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
                Cliente cliente = (Cliente)entity;
                if (ClienteExists(id))
                {
                    _context.Entry(cliente).State = EntityState.Modified;
                  
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
                Cliente cliente = (Cliente)entity;
                this._context.Clientes.Add(cliente);
         
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

            Cliente lClientes = await _context.Clientes.FindAsync(id);
            if (lClientes == null)
            {
                return null;
            }

            _context.Clientes.Remove(lClientes);
           await  _context.SaveChangesAsync();

            return lClientes;
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }
    }
}
