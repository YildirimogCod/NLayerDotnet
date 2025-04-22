using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Categories
{
    public class CategoryRepository(AppDbContext context) :GenericRepository<Category>(context),ICategoryRepository
    {
        public Task<Category?> GetCategoryWithProductAsync(int id)
        {
          return Context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id==id);
        }

        public IQueryable<Category?> GetCategoryByProductsAsync()
        {
           return Context.Categories.Include(x => x.Products).AsQueryable();
        }
    }
}
