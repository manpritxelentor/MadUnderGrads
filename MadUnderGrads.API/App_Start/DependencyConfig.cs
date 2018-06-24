using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation.WebApi;
using MadUnderGrads.API.Models;
using MadUnderGrads.API.Repository;
using MadUnderGrads.API.Service;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;

namespace MadUnderGrads.API.App_Start
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Register Context
            builder.RegisterType<ApplicationDbContext>()
                    .As<IDataContext>()
                    .InstancePerLifetimeScope();

            // Register All repository
            var repositoryTypes = typeof(ProductTextBookRepository).Assembly.GetTypes()
                .Where(w => w.Name.EndsWith("Repository")).ToArray();

            builder.RegisterTypes(repositoryTypes)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Register All services
            var serviceTypes = typeof(ProductTextBookService).Assembly.GetTypes()
                .Where(w => w.Name.EndsWith("Service")).ToArray();

            builder.RegisterTypes(serviceTypes)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<MappingUtility>()
                .As<IMappingUtility>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IdentityHelper>()
                .As<IIdentityHelper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailUtility>()
                .As<IEmailUtility>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ConfigurationUtility>()
                .As<IConfigurationUtility>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MemoryCacheUtility>()
                .As<ICacheUtility>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BackgroundUtility>()
                .As<IBackgroundUtility>()
                .InstancePerLifetimeScope();

            //Validation module registration
            builder.RegisterModule(new ValidationModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            FluentValidationModelValidatorProvider.Configure(config, w => w.ValidatorFactory = new AutofacValidatorFactory(container));
        }
    }
}