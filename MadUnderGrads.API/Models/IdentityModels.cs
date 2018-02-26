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

namespace MadUnderGrads.API.Models
{
    public class IBaseEntity
    {

    }


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHint { get; set; }
        public string PasswordReponse { get; set; }
        public DateTime? DateOfBirth { get; set; }

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

#if DEBUG
            Database.Log = s => { Trace.WriteLine(s); };
#endif
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(entityTypeConfiguration: new CategoryModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductApparelModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductElectronicsModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductFurnitureModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductMisellanousModelMap());
            modelBuilder.Configurations.Add(entityTypeConfiguration: new ProductTextbookModelMap());

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<CategoryModel> Categories { get; set; }

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

        public T GetById<T>(object id) where T : IBaseEntity => Set<T>().Find(id);
    }

    public class SampleDataInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Categories.Add(new CategoryModel
            {
                Id = 1,
                Name = "Textbooks"
            });
        }
    }
}