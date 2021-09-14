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
    public class FacturaVentasController : ControllerBase
    {
        private readonly FacturaVentaServiceInterface _FacturaVentaService;

        public FacturaVentasController(FacturaVentaServiceInterface facturaVentaService)
        {
            this._FacturaVentaService = facturaVentaService;
        }

        // GET: api/FacturaVentas
        [HttpGet]
        public async Task<ActionResult<RespuestaApiDto>> GetFacturaVenta()
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await _FacturaVentaService.FindAllFacturaVenta();

                return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/FacturaVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaApiDto>> GetFacturaVenta(int id)
        {
            RespuestaApiDto lRespuestaApiDto = await _FacturaVentaService.FindFacturaVentaById(id);

            if (lRespuestaApiDto == null || lRespuestaApiDto.facturaVenta == null)
            {
                return NotFound();
            }

            return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
        }

        // PUT: api/FacturaVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaVenta(int id, FacturaVenta facturaVenta)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                if (id != facturaVenta.id)
                {
                    return BadRequest();
                }

                lRespuestaApiDto = await this._FacturaVentaService.UpdateFacturaVenta(id, facturaVenta);

                if (lRespuestaApiDto == null || lRespuestaApiDto.facturaVenta == null)
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

        // POST: api/FacturaVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RespuestaApiDto>> PostFacturaVenta(FacturaVenta facturaVenta)
        {
            RespuestaApiDto lRespuestaApiDto;
            try {
                lRespuestaApiDto = await this._FacturaVentaService.CreateFacturaVenta(facturaVenta);
               return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception) { 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/FacturaVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaVenta(int id)
        {

            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._FacturaVentaService.RemoveFacturaVenta(id);

                if (lRespuestaApiDto == null || lRespuestaApiDto.facturaVenta == null)
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
