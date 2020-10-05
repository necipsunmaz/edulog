using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;
using System;
using System.Linq;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed.Core
{
    public static class PagePermissionCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            // 10000 den başlatmamızın nedeni seed page permissionlar ile dinamik eklenen yetkilerin çakışmaması
            modelBuilder.HasSequence<int>("PagePermissions_Id_seq", schema: "public")
            .StartsAt(10000)
            .IncrementsBy(1);

            // PagePermissions tablosunun başlangıç değerini 10000 e eşitler
            modelBuilder.Entity<PagePermission>()
           .Property(o => o.Id)
           .HasDefaultValueSql("nextval('\"PagePermissions_Id_seq\"')");

            // Admin tüm sayfalara yetkili olacağı için varsayılanda tüm sayfaları yetkili olarak tanımlıyoruz.
            modelBuilder.Entity<PagePermission>().HasData(PageCreator.Pages.Select(page => new PagePermission // Yönetim sayfalarını süzüyoruz.
            {
                Id = page.Id,
                UserRoleId = UserRoles.Admin,
                PageId = page.Id,
                DataStatus = DataStatus.Activated,
                CreatedById = 1,
                CreatedAt = new DateTime(2020, 10, 0)
            }));
        }
    }
}