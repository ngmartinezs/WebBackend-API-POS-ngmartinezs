using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Repository
{
    public interface FacturaVentaRepositoryInterface
    {
        public Task<IEnumerable<EntityRepository>> getAll();

        public Task<EntityRepository> findById(int id);

        public  Task<EntityRepository> update(int id, EntityRepository entiy);

        public  Task<EntityRepository> save(EntityRepository entiy);

        public  Task<EntityRepository> delete(int id);
    }
}
