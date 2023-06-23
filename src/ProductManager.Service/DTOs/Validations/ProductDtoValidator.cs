using FluentValidation;

namespace ProductManager.Service.DTOs.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(r => r.Code).NotEmpty().NotNull().GreaterThan(0).WithMessage("Check product code!");
            RuleFor(r => r.Description).NotEmpty().NotNull().WithMessage("Check product description!");
            RuleFor(r => r.Status).IsInEnum().WithMessage("Check product status!");
            RuleFor(r => r.FabricationDate).NotEmpty().NotNull().WithMessage("Check fabrication date status!");
            RuleFor(r => r.ProviderCode).NotEmpty().NotNull().WithMessage("Check provider code!");
            RuleFor(r => r.ProviderDescription).NotEmpty().NotNull().WithMessage("Check provider description!");
            RuleFor(r => r.CNPJ).NotEmpty().NotNull().WithMessage("Check CNPJ!");
        }
    }
}
