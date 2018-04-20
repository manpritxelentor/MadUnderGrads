using FluentValidation;
using MadUnderGrads.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels.Validator
{
    public class TeacherReviewValidator : AbstractValidator<TeacherReviewDataModel>
    {
        private readonly ITeacherService teacherService;

        public TeacherReviewValidator(ITeacherService teacherService)
        {
            RuleFor(w => w.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(300)
                .WithMessage("Description cannot be more than 300 characters");

            RuleFor(w => w.TeacherId)
                .Must((w, s) =>
                {
                    return teacherService.IsTeacherExists(w.TeacherId);
                })
                .WithMessage(x => $"Teacher id {x.TeacherId} does not exists");
        }
    }
}