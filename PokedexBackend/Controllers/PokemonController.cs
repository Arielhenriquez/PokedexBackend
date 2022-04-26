using Microsoft.AspNetCore.Mvc;
using PokedexBackend.Models;
using PokedexBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokedexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet(nameof(GetAllPokemons))]
        public async Task<ActionResult<List<AllPokemonInfo>>> GetAllPokemons()
        {
            var result = await _pokemonService.GetAllPokemons();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetPokemonName))]
        public async Task<IActionResult> GetPokemonName(string name)
        {
            var result = await _pokemonService.GetPokemonName(name);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }

       
    }
}
