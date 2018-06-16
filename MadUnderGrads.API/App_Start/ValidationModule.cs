using Autofac;
using FluentValidation;
using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.DataModels.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.App_Start
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductTextBookDataModelValidator>()
                .Keyed<IValidator>(typeof(IValidator<ProductTextBookDataModel>))
                .As<IValidator>();

            builder.RegisterType<TeacherReviewValidator>()
                .Keyed<IValidator>(typeof(IValidator<TeacherReviewDataModel>))
                .As<IValidator>();

            builder.RegisterType<ForgotPasswordDataModelValidator>()
                .Keyed<IValidator>(typeof(IValidator<ForgotPasswordDataModel>))
                .As<IValidator>();

            builder.RegisterType<ResetPasswordDataModelValidator>()
                .Keyed<IValidator>(typeof(IValidator<ResetPasswordDataModel>))
                .As<IValidator>();

            builder.RegisterType<ConfirmEmailDataModelValidator>()
                .Keyed<IValidator>(typeof(IValidator<ConfirmEmailDataModel>))
                .As<IValidator>();
            
        }
    }
}