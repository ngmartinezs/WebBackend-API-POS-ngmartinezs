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
    /// <summary>
    /// Deletes a specific TodoItem.
    /// </summary>
    [Route("apiPos/ngmartinezs/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteServiceInterface _clienteServiceInterface;

        public ClientesController(ClienteServiceInterface _clienteServiceInterface)
        {
            this._clienteServiceInterface = _clienteServiceInterface;
        }

        
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
