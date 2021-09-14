using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackendAPIPOSngmartinezs.DTO;
using WebBackendAPIPOSngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Service;

namespace WebBackendAPIPOSngmartinezs.Controllers
{
    [Route("apiPos/ngmartinezs/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteServiceInterface _clienteServiceInterface;

        public ClientesController(ClienteServiceInterface _clienteServiceInterface)
        {
            this._clienteServiceInterface = _clienteServiceInterface;
        }

        // GET: api/Clientes
        // GET: api/Pais/5
        /// <summary>
        /// Obtiene un objeto por su Id.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su Id.
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>

        [HttpGet]
        public async Task<ActionResult<RespuestaApiDto>> GetClientes()
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._clienteServiceInterface.FindAllCliente();

                return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Clientes/5
        /// <summary>
        /// Obtiene un objeto por su Id.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su Id.
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>

        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaApiDto>> GetCliente(int id)
        {
           
            RespuestaApiDto lRespuestaApiDto = await this._clienteServiceInterface.FindClienteById(id);

            if (lRespuestaApiDto == null || lRespuestaApiDto.cliente == null)
            {
                return NotFound();
            }

            return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
        }

        // PUT: api/Clientes/5
        /// <summary>
        /// Crea un nuevo objeto en la BD.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Crea un nuevo objeto en la BD.
        /// </remarks>
        /// <param name="pais">Objeto a crear en la BD.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
           
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                if (id != cliente.id)
                {
                    return BadRequest();
                }

                lRespuestaApiDto = await this._clienteServiceInterface.UpdateCliente(id, cliente);

                if (lRespuestaApiDto == null || lRespuestaApiDto.cliente == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Clientes
        /// <summary>
        /// Crea un nuevo objeto en la BD.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Crea un nuevo objeto en la BD.
        /// </remarks>
        /// <param name="pais">Objeto a crear en la BD.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>

        [HttpPost]
        public async Task<ActionResult<RespuestaApiDto>> PostCliente(Cliente cliente)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._clienteServiceInterface.CreateCliente(cliente);
                return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Clientes/5
        /// <summary>
        /// Crea un nuevo objeto en la BD.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Crea un nuevo objeto en la BD.
        /// </remarks>
        /// <param name="pais">Objeto a crear en la BD.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="409">Conflict. El objeto a crear ya existe en la BD.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._clienteServiceInterface.RemoveCliente(id);

                if (lRespuestaApiDto == null || lRespuestaApiDto.cliente == null)
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }
}
