using PokemonReviewApp_youtube.Models;
using PokemonReviewApp_youtube.Repositories;

namespace PokemonReviewApp_youtube.Services.Impl
{
    public class OwnerServiceImpl : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerServiceImpl(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public ICollection<Owner> FindAll()
        {
            return _ownerRepository.FindAll();
        }

        public Owner FindById(int ownerId)
        {
            return _ownerRepository.FindById(ownerId);
        }

        public bool OwnerExists(int ownerId)
        {
            return _ownerRepository.OwnerExists(ownerId);
        }
    }
}
