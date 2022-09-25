﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp_youtube.Dto;
using PokemonReviewApp_youtube.Models;
using PokemonReviewApp_youtube.Services;

namespace PokemonReviewApp_youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonDto>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonService.GetPokemons());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonById(int pokemonId)
        {
            if (!PokemonExists(pokemonId)) return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_pokemonService.GetPokemonById(pokemonId));
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }
        
        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId)
        {
            if (!PokemonExists(pokemonId)) return NotFound();
            var pokemonRating = _pokemonService.GetPokemonRating(pokemonId);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemonRating);
        }

        private bool PokemonExists(int pokemonId)
        {
            return _pokemonService.PokemonExists(pokemonId);
        }
    }
}
