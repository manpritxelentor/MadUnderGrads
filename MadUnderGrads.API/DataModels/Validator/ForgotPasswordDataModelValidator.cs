using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ForgotPasswordDataModelValidator : AbstractValidator<ForgotPasswordDataModel>
    {
        public ForgotPasswordDataModelValidator()
        {
            RuleFor(w => w.Email)
                .NotEmpty()
                .When(w => string.IsNullOrEmpty(w.UserName))
                .WithMessage("Please provide username or email");

            RuleFor(w => w.UserName)
                .NotEmpty()
                .When(w => string.IsNullOrEmpty(w.Email))
                .WithMessage("Please provide username or email");
        }
    }
}