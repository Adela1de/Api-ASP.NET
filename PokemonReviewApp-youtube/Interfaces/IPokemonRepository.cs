using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
