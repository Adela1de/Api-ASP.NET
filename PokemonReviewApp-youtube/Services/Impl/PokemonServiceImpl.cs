using PokemonReviewApp_youtube.Models;
using PokemonReviewApp_youtube.Repositories;

namespace PokemonReviewApp_youtube.Services.Impl
{
    public class PokemonServiceImpl : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonServiceImpl(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        public Pokemon GetPokemonById(int pokemonId)
        {
            return _pokemonRepository.FindById(pokemonId);
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var pokemon = _pokemonRepository.FindById(pokemonId);
            var reviews = _pokemonRepository.GetReviewsForAPokemon(pokemon);
            var reviewSize = reviews == null ? 0 : reviews.Count();

            if (reviewSize <= 0) return 0;

            return (decimal) reviews.Sum(r => r.Rating) / reviewSize;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _pokemonRepository.FindAll();
        }

        public bool PokemonExists(int pokemonId)
        {
            return (_pokemonRepository.PokemonExists(pokemonId));
        }

        public Pokemon SavePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
