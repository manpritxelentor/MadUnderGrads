using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Diagnostics;
using System;
using MadUnderGrads.API.Models.Configurations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using log4net;

namespace MadUnderGrads.API.Models
{
    public class IBaseEntity
    {

    }


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreatedProducts = new List<ProductModel>();
            UpdatedProducts = new List<ProductModel>();
            TeacherReviews = new List<TeacherReviewModel>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHint { get; set; }
        public string PasswordReponse { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<ProductModel> CreatedProducts { get; set; }
        public virtual ICollection<ProductModel> UpdatedProducts { get; set; }
        public virtual ICollection<TeacherReviewModel> TeacherReviews { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
            ILog logger = LogManager.GetLogger("QueryAppender");

            Database.Log = s =>
            {
                logger.Debug(s);
#if DEBUG
                Trace.WriteLine(s);
#endif
            };
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Adding all mapping class using reflection
            modelBuilder.Configurations.AddFromNamespaceContainingType<CategoryModelMap>();

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> Entities<T>() where T : IBaseEntity
        {
            return Set<T>();
        }

        public IQueryable<T> EntitiesNoTracking<T>() where T : IBaseEntity
        {
            return Set<T>().AsNoTracking();
        }

        public void Delete<T>(T entity) where T : IBaseEntity
        {
            Set<T>().Remove(entity);
        }

        public void Insert<T>(T entity) where T : IBaseEntity
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : IBaseEntity
        {
            // Nothing to do here
        }

        public T Create<T>() where T : IBaseEntity
        {
            return Set<T>().Create();
        }

        public T GetById<T>(object id) where T : IBaseEntity => Set<T>().Find(id);
    }


    public static class EFExtensions
    {
        public static void AddFromNamespaceContainingType<TEntityType>(this ConfigurationRegistrar configRegistrar)
            where TEntityType : class
        {
            var entityType = typeof(TEntityType);
            var configTypeInfo = entityType.Assembly.GetTypes()
                .Where(x => x.Namespace == entityType.Namespace &&
                            x.BaseType != null &&
                            x.BaseType.IsGenericType &&
                            x.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))
                .Select(x => new
                {
                    ConfigType = x,
                    EntityType = x.BaseType.GetGenericArguments()[0]
                })
                .ToArray();

            foreach (var configInfo in configTypeInfo)
            {
                AddConfigToRegistrar(configInfo.ConfigType, configInfo.EntityType, configRegistrar);
            }
        }

        private static void AddConfigToRegistrar(Type configType, Type entityType, ConfigurationRegistrar configRegistrar)
        {
            var addMethod = typeof(ConfigurationRegistrar)
                .GetMethods()
                .Single(x => x.Name == "Add" && x.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>))
                .MakeGenericMethod(entityType);

            var configInstance = Activator.CreateInstance(configType);

            addMethod.Invoke(configRegistrar, new[] { configInstance });
        }
    }
}