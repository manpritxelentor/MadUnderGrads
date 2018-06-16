using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class UpdateProfileDataModelValidator : AbstractValidator<UpdateProfileDataModel>
    {
        public UpdateProfileDataModelValidator()
        {
            RuleFor(w => w.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
        }
    }
}