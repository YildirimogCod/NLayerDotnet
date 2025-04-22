using App.Services.Products;

namespace App.Services.Categories
{
    public record CategoriesWithProductsDto(int Id, string Name, List<ProductDto> Products);
}
