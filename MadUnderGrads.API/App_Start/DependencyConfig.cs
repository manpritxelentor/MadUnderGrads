using Autofac;
using Autofac.Integration.WebApi;
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
            builder.RegisterType<ProductTextBookRepository>()
                .As<IProductTextBookRepository>()
                .InstancePerLifetimeScope();

            // Register All services
            builder.RegisterType<ProductTextBookService>()
                .As<IProductTextBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MappingUtility>()
                .As<IMappingUtility>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}