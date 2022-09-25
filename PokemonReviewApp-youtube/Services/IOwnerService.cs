using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Services
{
    public interface IOwnerService
    {
        ICollection<Owner> FindAll();
        Owner FindById(int OwnerId);
        bool OwnerExists(int ownerId);
    }
}
