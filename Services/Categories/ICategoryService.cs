using App.Services.Products.Create;
using System.Threading.Tasks;

namespace App.Services.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoriesWithProductsDto>> GetCategoryWithProductAsync(int id);
        Task<ServiceResult<List<CategoriesWithProductsDto>>> GetCategoryByProductsAsync();
        Task<ServiceResult<List<CategoriesDto>>> GetAllListAsync();
        Task<ServiceResult<CategoriesDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);

        Task<ServiceResult> DeleteAsync(int id);
    }
}
