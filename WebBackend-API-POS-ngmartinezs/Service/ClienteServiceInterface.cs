using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;

namespace WebBackendAPIPOSngmartinezs.Service
{
    public interface ClienteServiceInterface
    {

        public  Task<RespuestaApiDto> FindAllCliente();

        public  Task<RespuestaApiDto> FindClienteById(int id);
        public  Task<RespuestaApiDto> UpdateCliente(int id, Cliente cliente);

        public  Task<RespuestaApiDto> CreateCliente(Cliente cliente);

        public  Task<RespuestaApiDto> RemoveCliente(int id);
    }
}
