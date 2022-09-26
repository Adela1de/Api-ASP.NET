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

        public Pokemon FindById(int id)
        {
            return _dataContext.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon FindByName(string name)
        {
            return _dataContext.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsForAPokemon(Pokemon pokemon)
        {
            return _dataContext.Reviews.Where(r => r.Pokemon == pokemon).ToList();
        }

        public ICollection<Pokemon> FindAll()
        {
            return _dataContext.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemonId)
        {
            return _dataContext.Pokemons.Any(p => p.Id == pokemonId);
        }

        public bool SavePokemon(Owner owner, Category category, Pokemon pokemon)
        {
            var pokemonOwner = new PokemonOwner()
            {
                Pokemon = pokemon,
                Owner = owner,
            };

            _dataContext.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Pokemon = pokemon,
                Category = category,
            };

            _dataContext.Add(pokemonCategory);

            _dataContext.Add(pokemon);

            return Save();
        }

        private bool Save()
        {
            return _dataContext.SaveChanges() > 0 ? true : false;
        }

    }
}
