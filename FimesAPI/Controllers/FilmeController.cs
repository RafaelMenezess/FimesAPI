using FimesAPI.Data;
using FimesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FimesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFimesPorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFimes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFimesPorId([FromRoute] int id)
        {
            var fime = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (fime != null)
            {
                return Ok(fime);
            }
            return NotFound();
        }
    }
}
