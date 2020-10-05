using Microsoft.EntityFrameworkCore;
using EduLog.DataAccess.Concrete.EntityFramework.Seed.Core;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed
{
    public static class SeedCreatorExtension
    {
        public static void CreateSeed(this ModelBuilder modelBuilder)
        {
            #region Core

            PageCreator.Create(modelBuilder);
            PagePermissionCreator.Create(modelBuilder);
            SettingCreator.Create(modelBuilder);
            UserCreator.Create(modelBuilder);
            UserRoleCreator.Create(modelBuilder);

            #endregion Core
        }
    }
}