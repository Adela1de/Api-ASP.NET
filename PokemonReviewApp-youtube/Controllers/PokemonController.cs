

using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp_youtube.Dto;
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

        [HttpGet("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult getPokemonById(int pokemonId)
        {
            if (!_pokemonRepository.PokemonExists(pokemonId)) return NotFound();
            var pokemon = _pokemonRepository.GetPokemonById(pokemonId);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }

        /*
        [HttpGet("{pokemonName}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult getPokemonByName(string pokemonName)
        {
            var pokemon = _pokemonRepository.GetPokemonByName(pokemonName);
            if (pokemon == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            return Ok(pokemon);
        }
        */

        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult getPokemonRating(int pokemonId)
        {
            var pokemonRating = _pokemonRepository.GetPokemonRating(pokemonId);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemonRating);
        }
    }
}
