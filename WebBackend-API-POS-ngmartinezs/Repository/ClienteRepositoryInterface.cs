using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public interface ClienteRepositoryInterface
    {
        public Task<IEnumerable<EntityRepository>> getAll();

        public Task<EntityRepository> findById(int id);

        public Task<EntityRepository> update(int id, EntityRepository entity);

        public Task<EntityRepository> save(EntityRepository entity);

        public Task<EntityRepository> delete(int id);
    }
}
