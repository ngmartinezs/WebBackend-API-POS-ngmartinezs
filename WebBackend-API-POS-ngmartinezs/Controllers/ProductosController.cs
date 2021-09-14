using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackend_API_POS_ngmartinezs.Models;
using WebBackendAPIPOSngmartinezs.Service;
using WebBackendAPIPOSngmartinezs.DTO;

namespace WebBackendAPIPOSngmartinezs.Controllers
{
    [Route("apiPos/ngmartinezs/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        //private readonly WebBackendAPIPOSngmartinezsContext _context;
        private readonly ProductoServiceInterface _productoServiceInterface;

        public ProductosController(ProductoServiceInterface productoServiceInterface)
        {
            this._productoServiceInterface = productoServiceInterface;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<RespuestaApiDto>> GetProductos()
        {
       
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await _productoServiceInterface.FindAllProducto();

                return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaApiDto>> GetProductos(int id)
        {
            RespuestaApiDto lRespuestaApiDto = await _productoServiceInterface.FindProductoById(id);

            if (lRespuestaApiDto == null || lRespuestaApiDto.facturaVenta == null)
            {
                return NotFound();
            }

            return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Producto productos)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                if (id != productos.id)
                {
                    return BadRequest();
                }

                lRespuestaApiDto = await this._productoServiceInterface.UpdateProducto(id, productos);

                if (lRespuestaApiDto == null || lRespuestaApiDto.producto == null)
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

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<RespuestaApiDto>> PostProductos(Producto productos)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._productoServiceInterface.CreateProducto(productos);
                return new ActionResult<RespuestaApiDto>(lRespuestaApiDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            RespuestaApiDto lRespuestaApiDto;
            try
            {
                lRespuestaApiDto = await this._productoServiceInterface.RemoveProducto(id);

                if (lRespuestaApiDto == null || lRespuestaApiDto.producto == null)
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
