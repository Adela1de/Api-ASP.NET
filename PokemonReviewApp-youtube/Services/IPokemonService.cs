using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Services
{
    public interface IPokemonService
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int pokemonId);
        decimal GetPokemonRating(int pokemonId);
        public bool PokemonExists(int pokemonId);
        string SavePokemon(int ownerId, int categoryId, Pokemon pokemon);
        Pokemon GetByName(string pokemonName);
        bool CreateCategory(Category category);
        Category GetCategoryByName(String name);
    }
}
