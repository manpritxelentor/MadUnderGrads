using FluentValidation;
using MadUnderGrads.API.Service;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ProductTextBookDataModelValidator : AbstractValidator<ProductTextBookDataModel>
    {
        public ProductTextBookDataModelValidator() 
        {
            RuleFor(w => w.Title)
                .NotEmpty()
                .WithMessage("Title is required");
        }
    }
}