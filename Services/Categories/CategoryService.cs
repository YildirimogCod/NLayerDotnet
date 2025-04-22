using System.Net;
using App.Repositories;
using App.Repositories.Categories;
using App.Repositories.Products;
using App.Services.Products.Create;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository,IMapper mapper,IUnitOfWork unitOfWork):ICategoryService
    {
        public async Task<ServiceResult<CategoriesWithProductsDto>> GetCategoryWithProductAsync(int id)
        {
            var category = await categoryRepository.GetCategoryWithProductAsync(id);
            if (category is null)
            {
                return ServiceResult<CategoriesWithProductsDto>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }
            var categoryDto = mapper.Map<CategoriesWithProductsDto>(category);
            return ServiceResult<CategoriesWithProductsDto>.Success(categoryDto);
        }
        public async Task<ServiceResult<List<CategoriesWithProductsDto>>> GetCategoryByProductsAsync()
        {
            var categories = await categoryRepository.GetCategoryByProductsAsync().ToListAsync();
            var categoriesDto = mapper.Map<List<CategoriesWithProductsDto>>(categories);
            return ServiceResult<List<CategoriesWithProductsDto>>.Success(categoriesDto);
        }
        //crud operations
        //get category with products
        //get category by products
        public async Task<ServiceResult<List<CategoriesDto>>> GetAllListAsync()
        {
            var categories = await categoryRepository.GetAll().ToListAsync();
            var categoriesDto = mapper.Map<List<CategoriesDto>>(categories);
            return ServiceResult<List<CategoriesDto>>.Success(categoriesDto);
        }

        public async Task<ServiceResult<CategoriesDto>> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult<CategoriesDto>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }
            var categoryDto = mapper.Map<CategoriesDto>(category);
            return ServiceResult<CategoriesDto>.Success(categoryDto);
        }

        //create crud operations method
        public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
        {
            var anyCategory = await categoryRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyCategory)
            {
                return ServiceResult<int>.Fail("categori ismi veritabanında bulunmamaktadır.",HttpStatusCode.NotFound);
            }

            var newCategory = new Category() { Name = request.Name };
            await categoryRepository.AddAsync(newCategory);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult<int>.Success(newCategory.Id);
        }
        public async Task<ServiceResult> UpdateAsync(int id,UpdateCategoryRequest request)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult.Fail("Güncellenecek kategori bulunamadı",HttpStatusCode.NotFound);
            }

            var isCategoryNameExist = await categoryRepository.Where(x => x.Name == request.Name && x.Id != category.Id)
                .AnyAsync();
            if (isCategoryNameExist)
            {
                return ServiceResult.Fail("Kategori ismi veritabında bulunmaktadır.",HttpStatusCode.BadRequest);
            }

            category = mapper.Map(request, category);
            categoryRepository.Update(category);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return ServiceResult.Fail("Silinecek kategori bulunamadı", HttpStatusCode.NotFound);
            }
            categoryRepository.Delete(category);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
