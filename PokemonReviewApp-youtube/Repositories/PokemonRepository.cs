using PokemonReviewApp_youtube.Data;
using PokemonReviewApp_youtube.Interfaces;
using PokemonReviewApp_youtube.Models;
using System.Linq;

namespace PokemonReviewApp_youtube.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _dataContext;
        public PokemonRepository(DataContext context) 
        {
            _dataContext = context;
        }

        public Pokemon GetPokemonById(int id)
        {
            return _dataContext.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _dataContext.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var review = _dataContext.Reviews.Where(r => r.Pokemon.Id == pokemonId);
            var reviewSize = review == null ? 0 : review.Count();

            if (reviewSize <= 0) return 0;

            return (decimal) review.Sum(r => r.Rating) / reviewSize;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _dataContext.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemonId)
        {
            return _dataContext.Pokemons.Any(p => p.Id == pokemonId);
        }
    }
}
