using PokemonReviewApp_youtube.Data;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Repositories.Impl
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepositoryImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateCategory(Category category)
        {
            _dataContext.Add(category);
            return Save();
        }

        public Category FindById(int categoryId)
        {
            return _dataContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public Category FindByName(string name)
        {
            return _dataContext
                .Categories
                .Where(c => c.Name.Trim().ToUpper() == name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        private bool Save()
        {
            return _dataContext.SaveChanges() > 0 ? true : false;
        }
    }
}
