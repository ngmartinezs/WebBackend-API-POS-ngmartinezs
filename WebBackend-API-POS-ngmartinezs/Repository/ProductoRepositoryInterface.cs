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
    public interface ProductoRepositoryInterface
    {
        public Task<IEnumerable<EntityRepository>> getAll();

        public Task<EntityRepository> findById(int id);

        public Task<EntityRepository> update(int id, EntityRepository entity);

        public Task<EntityRepository> save(EntityRepository entity);

        public Task<EntityRepository> delete(int id);

    }
}
