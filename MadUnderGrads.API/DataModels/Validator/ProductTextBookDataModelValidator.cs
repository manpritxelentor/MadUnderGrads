using FluentValidation;
using MadUnderGrads.API.Service;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ProductTextBookDataModelValidator : AbstractValidator<ProductTextBookDataModel>
    {
        public ProductTextBookDataModelValidator(ICategoryService categoryService) 
        {
            RuleFor(w => w.Title)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(w => w.CategoryId)
                .Must(w => categoryService.IsCategoryPresent(w))
                .WithMessage("Category not found. Please select valid category");
        }
    }
}