using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int pokemonId);
        Pokemon GetPokemonByName(string name);
        decimal GetPokemonRating(int pokemonId);
        public bool PokemonExists(int pokemonId);
    }
}
