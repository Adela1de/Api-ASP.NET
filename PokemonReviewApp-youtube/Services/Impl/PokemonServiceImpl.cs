using PokemonReviewApp_youtube.Exceptions;
using PokemonReviewApp_youtube.Models;
using PokemonReviewApp_youtube.Repositories;

namespace PokemonReviewApp_youtube.Services.Impl
{
    public class PokemonServiceImpl : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PokemonServiceImpl(
            IPokemonRepository pokemonRepository,
            IOwnerRepository ownerRepository,
            ICategoryRepository categoryRepository)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository;
            _categoryRepository = categoryRepository;

        }
        public Pokemon GetPokemonById(int pokemonId)
        {
            return _pokemonRepository.FindById(pokemonId);
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var pokemon = _pokemonRepository.FindById(pokemonId);
            var reviews = _pokemonRepository.GetReviewsForAPokemon(pokemon);
            var reviewSize = reviews == null ? 0 : reviews.Count();

            if (reviewSize <= 0) return 0;

            return (decimal) reviews.Sum(r => r.Rating) / reviewSize;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _pokemonRepository.FindAll();
        }

        public bool PokemonExists(int pokemonId)
        {
            return (_pokemonRepository.PokemonExists(pokemonId));
        }

        public bool SavePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var ownerEntity = findOwnerByIdOrElseThrowException(ownerId);
            var categoryEntity = findCategoryByIdOrElseThrowException(categoryId);
            if (!_pokemonRepository.SavePokemon(ownerEntity, categoryEntity, pokemon))
                throw new CouldNotSavePokemonException("Error trying to save pokemon");

            return true;
        }

        private Owner findOwnerByIdOrElseThrowException(int ownerId)
        {
            var owner = _ownerRepository.FindById(ownerId);
            if (owner == null) throw new ObjectNotFoundException("Owner not found!");
            return owner;
        }

        private Category findCategoryByIdOrElseThrowException(int categoryId)
        {
            var category = _categoryRepository.FindById(categoryId);
            if (category == null) throw new ObjectNotFoundException("Category not found!");
            return category;
        }

        public Pokemon GetByName(string pokemonName)
        {
            return _pokemonRepository.FindByName(pokemonName);
        }

        public bool CreateCategory(Category category)
        {
            var created = _categoryRepository.CreateCategory(category);
            if (!created) throw new SavingException("Could not create cateory");
            return created;
        }

        public Category GetCategoryByName(string name)
        {
            return _categoryRepository.FindByName(name);
        }

        public bool DeletePokemon(int pokemonId)
        {
            return _pokemonRepository.DeletePokemon(pokemonId);
        }
    }
}
