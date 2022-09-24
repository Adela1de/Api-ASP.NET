

using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp_youtube.Interfaces;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult getPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
