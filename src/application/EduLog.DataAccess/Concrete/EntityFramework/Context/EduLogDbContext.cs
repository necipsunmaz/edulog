using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;
using EduLog.Core.Utilities.Attributes;
using EduLog.DataAccess.Concrete.EntityFramework.Seed;
using System.Reflection;

namespace EduLog.DataAccess.Concrete.EntityFramework.Context
{
    public class EduLogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PagePermission> PagePermissions { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// https://docs.microsoft.com/en-us/ef/core/modeling/indexes#indexes
            /// </summary>
            /// IndexAttribute ile oluşturulan indexleri create eder.
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in entity.GetProperties())
                {
                    try
                    {
                        var attr = prop.PropertyInfo.GetCustomAttribute<IndexAttribute>();
                        if (attr != null)
                        {
                            var index = entity.AddIndex(prop);
                            index.IsUnique = attr.IsUnique;
                        }
                    }
                    catch { }
                }
            }

            // Seed (Sabit verileri database ile senkronize eder)
            modelBuilder.CreateSeed();

            base.OnModelCreating(modelBuilder);
        }
    }
}