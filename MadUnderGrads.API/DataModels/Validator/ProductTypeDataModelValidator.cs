using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ProductTypeDataModelValidator : AbstractValidator<ProductTypeDataModel>
    {
        public ProductTypeDataModelValidator()
        {
            RuleFor(w => w.Code)
                .NotEmpty()
                .WithMessage("Code is required");

            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(w => w.CategoryId)
                .NotEmpty()
                .WithMessage("Category is required");
        }
    }
}