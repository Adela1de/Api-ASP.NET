using PokemonReviewApp_youtube.Data;
using PokemonReviewApp_youtube.Interfaces;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _dataContext;
        public PokemonRepository(DataContext context) 
        {
            _dataContext = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _dataContext.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
