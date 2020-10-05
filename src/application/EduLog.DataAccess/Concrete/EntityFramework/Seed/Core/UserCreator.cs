using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;
using System;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed.Core
{
    public static class UserCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] {
                    new User {
                        Id = 1,
                        UserRoleId = UserRoles.Admin,
                        Name = "Super",
                        Surname ="Admin",
                        Email = "admin@onweblog.com",
                        Password = "9K7Cwg3Qw/8FR/S9VvrNdgl8znxhPagMZ4QrajV/3AQ=", // admin
                        CreatedAt = new DateTime(2020, 10, 0),
                        DataStatus = DataStatus.Activated
                    }
            });
        }
    }
}