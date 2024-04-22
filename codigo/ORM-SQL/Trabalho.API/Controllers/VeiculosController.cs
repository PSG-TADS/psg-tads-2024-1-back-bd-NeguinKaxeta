using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Trabalho.API;

namespace Trabalho.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public VeiculosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        // GET: /mod/{modelo}
        [HttpGet("/mod/{modelo}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosByModel(string modelo)
        {
            return await _context.Veiculos.Where(t => t.Modelo == modelo).ToListAsync();
        }

        // GET: /marca/{marca}
        [HttpGet("/marca/{marca}")]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculosByMarca(string marca)
        {
            return await _context.Veiculos.Where(t => t.Marca == marca).ToListAsync();
        }

        // GET: /{id}
        [HttpGet("/{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // POST: /
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return Created($"/{veiculo.Id}", veiculo);
        }

        // PUT: /{id}
        [HttpPut("/{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // DELETE: /Veiculos/{id}
        [HttpDelete("/Veiculos/{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var product = await _context.Veiculos.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }
    }
}
