using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ConfirmEmailDataModelValidator : AbstractValidator<ConfirmEmailDataModel>
    {
        public ConfirmEmailDataModelValidator()
        {
            RuleFor(w => w.Email)
              .NotEmpty()
              .WithMessage("Email is required");

            RuleFor(w => w.Code)
                .NotEmpty()
                .WithMessage("Reset Code is required");
        }
    }
}