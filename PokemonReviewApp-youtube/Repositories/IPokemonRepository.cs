using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int pokemonId);
        Pokemon GetPokemonByName(string name);
        ICollection<Review> GetReviewsForAPokemon(Pokemon pokemon);
        public bool PokemonExists(int pokemonId);
        Pokemon SavePokemon(Pokemon pokemon);
    }
}
