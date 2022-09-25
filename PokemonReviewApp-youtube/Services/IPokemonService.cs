using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Services
{
    public interface IPokemonService
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int pokemonId);
        decimal GetPokemonRating(int pokemonId);
        public bool PokemonExists(int pokemonId);
        Pokemon SavePokemon(Pokemon pokemon);
    }
}
