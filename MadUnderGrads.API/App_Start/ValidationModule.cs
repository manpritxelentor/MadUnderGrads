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
            
        }
    }
}