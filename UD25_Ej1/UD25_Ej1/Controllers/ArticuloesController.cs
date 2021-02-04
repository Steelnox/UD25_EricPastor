using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UD25_Ej1.Models;
using UD25_Ej1.DTO;
using System.Linq.Expressions;

namespace UD25_Ej1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloesController : ControllerBase
    {
        private readonly APIContext _context;

        private static readonly Expression<Func<Articulo, ArticuloDTO>> AsArticuloDTO =
            x => new ArticuloDTO
            {
                Nombre = x.Nombre,
                Precio = x.Precio
            };

        public ArticuloesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Articuloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/Articuloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articuloes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articuloes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.Codigo }, articulo);
        }

        // DELETE: api/Articuloes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return articulo;
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Codigo == id);
        }

        [HttpGet("~/api/Articulo/Nombre/{nombre}")]
        public IQueryable<ArticuloDTO> GetArticuloByNombre(string nombre)
        {
            return _context.Articulos.Where(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                .Select(AsArticuloDTO);
        }

    }
}
