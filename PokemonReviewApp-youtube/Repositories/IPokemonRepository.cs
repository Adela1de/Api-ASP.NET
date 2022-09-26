using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> FindAll();
        Pokemon FindById(int pokemonId);
        Pokemon FindByName(string name);
        ICollection<Review> GetReviewsForAPokemon(Pokemon pokemon);
        public bool PokemonExists(int pokemonId);
        bool SavePokemon(Owner owner, Category category, Pokemon pokemon);
    }
}
