using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories
{
    public interface IOwnerRepository
    {
        ICollection<Owner> FindAll();
        Owner FindById(int id);
        bool OwnerExists(int ownerId);
    }
}
