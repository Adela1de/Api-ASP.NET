using PokemonReviewApp_youtube.Data;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories.Impl
{
    public class PokemonRepositoryImpl : IPokemonRepository
    {
        private readonly DataContext _dataContext;
        public PokemonRepositoryImpl(DataContext context)
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

        public ICollection<Review> GetReviewsForAPokemon(Pokemon pokemon)
        {
            return _dataContext.Reviews.Where(r => r.Pokemon == pokemon).ToList();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _dataContext.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemonId)
        {
            return _dataContext.Pokemons.Any(p => p.Id == pokemonId);
        }

        public Pokemon SavePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
