using FluentValidation;

namespace App.Services.Products.Update
{
    public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün ismi gereklidir.")
                .Length(3, 10).WithMessage("Ürün ismi 3 ila 10 karakter arasında olmalıdır.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("0'dan büyük olmalıdır.");
            RuleFor(x => x.Stock).InclusiveBetween(1, 100).WithMessage("1 ile 100 arasında olmalıdır.");
        }
    }
}
