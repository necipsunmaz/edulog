using EduLog.Core.Entities.Concrete;
using EduLog.Core.Utilities.Attributes;
using EduLog.DataAccess.Concrete.EntityFramework.Seed;
using EduLog.Entities.Concrete.Categories;
using EduLog.Entities.Concrete.Comments;
using EduLog.Entities.Concrete.Media;
using EduLog.Entities.Concrete.Navigations;
using EduLog.Entities.Concrete.Posts;
using EduLog.Entities.Concrete.Projects;
using EduLog.Entities.Concrete.Tags;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EduLog.DataAccess.Concrete.EntityFramework.Context
{
    public class EduLogDbContext : DbContext
    {
        #region Core

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PagePermission> PagePermissions { get; set; }
        public DbSet<Setting> Settings { get; set; }

        #endregion Core

        #region Entities

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectLink> ProjectLinks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        #endregion Entities

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