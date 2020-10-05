using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed.Core
{
    public static class UserRoleCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] {
                    new UserRole { Id = UserRoles.Admin, Name = "Super Admin"},
                    new UserRole { Id = UserRoles.Editor, Name = "Editor"},
                    new UserRole { Id = UserRoles.Member, Name = "Member"}
            });
        }
    }
}