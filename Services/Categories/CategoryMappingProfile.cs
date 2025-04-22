using App.Repositories.Categories;
using App.Services.Products.Create;
using AutoMapper;

namespace App.Services.Categories
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoriesDto,Category >().ReverseMap();

            CreateMap<Category, CategoriesWithProductsDto>();

            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Products, opt => opt.Ignore());
            CreateMap<UpdateCategoryRequest, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Products, opt => opt.Ignore());

        }
    }
}
