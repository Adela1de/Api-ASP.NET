using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories
{
    public interface ICategoryRepository
    {
        Category FindById(int categoryId);
        Category FindByName(string name);
        bool CreateCategory(Category category);
    }
}
