using PokemonReviewApp_youtube.Data;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories.Impl
{
    public class OwnerRepositoryImpl : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepositoryImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Owner> FindAll()
        {
            return _dataContext.Owners.OrderBy(o => o.Id).ToList();
        }

        public Owner FindById(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public bool OwnerExists(int ownerId)
        {
            return _dataContext.Owners.Any(o => o.Id == ownerId);
        }
    }
}
