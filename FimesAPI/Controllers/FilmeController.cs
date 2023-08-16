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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFimesPorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFimes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFimesPorId([FromRoute] int id)
        {
            var fime = filmes.FirstOrDefault(filme => filme.Id == id);
            if (fime != null)
            {
                return Ok(fime);
            }
            return NotFound();
        }
    }
}
