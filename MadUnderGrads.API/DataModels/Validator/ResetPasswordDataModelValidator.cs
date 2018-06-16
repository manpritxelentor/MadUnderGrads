using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class ResetPasswordDataModelValidator : AbstractValidator<ResetPasswordDataModel>
    {
        public ResetPasswordDataModelValidator()
        {
            RuleFor(w => w.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(w => w.Code)
                .NotEmpty()
                .WithMessage("Reset Code is required");

            RuleFor(w => w.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(w => w.ConfirmPassword)
                .NotEmpty()
                .WithMessage("ConfirmPassword is required")
                .Must((m, s) =>
                {
                    return m.Password.Equals(s, StringComparison.CurrentCulture);
                })
                .WithMessage("Password and Confirm password must be same");
        }
    }
}