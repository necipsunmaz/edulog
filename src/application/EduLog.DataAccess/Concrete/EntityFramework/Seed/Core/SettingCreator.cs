using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed.Core
{
    public static class SettingCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>().HasData(new Setting[] {
                    new Setting { Id = Settings.Title, Value = "EduLog - On Web Log"},
                    new Setting { Id = Settings.Description, Value = "EduLog is a small web application for software design education."},
                    new Setting { Id = Settings.Email, Value = "info@onweblog.com"},
                    new Setting { Id = Settings.SystemEmail, Value = "noreply@onweblog.com"}
            });
        }
    }
}