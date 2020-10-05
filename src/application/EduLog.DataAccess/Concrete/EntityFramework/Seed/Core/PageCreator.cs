using Microsoft.EntityFrameworkCore;
using EduLog.Core.Entities.Concrete;

namespace EduLog.DataAccess.Concrete.EntityFramework.Seed.Core
{
    public static class PageCreator
    {
        public static readonly Page[] Pages = new Page[] {
                new Page
                {
                    Id = 1,
                    ParentId = null,
                    Order = 0,
                    Name = "Dashboard",
                    RouterLink = "/dashboard",
                    Visible = false
                },
                new Page
                {
                    Id = 2,
                    ParentId = 1,
                    Order = 0,
                    Name = "Home",
                    Breadcrump = "Dashboard / Home",
                    RouterLink = "/dashboard/home",
                    Icon = "fa fa-home",
                    Visible = true
                },
                new Page
                {
                    Id = 3,
                    ParentId = 1,
                    Order = 70,
                    Name = "Users",
                    Breadcrump = "Dashboard / Users",
                    RouterLink = "/dashboard/users",
                    Icon = "fa fa-user",
                    Visible = true
                },
                new Page
                {
                    Id = 4,
                    ParentId = 3,
                    Order = 0,
                    Name = "All Users",
                    Breadcrump = "Dashboard / All Users",
                    RouterLink = "/dashboard/users/all-users",
                    Visible = true
                },
                new Page
                {
                    Id = 5,
                    ParentId = 3,
                    Order = 1,
                    Name = "New User",
                    Breadcrump = "Dashboard / New User",
                    RouterLink = "/dashboard/users/new-user",
                    Visible = true
                },
                new Page
                {
                    Id = 6,
                    ParentId = 1,
                    Order = 99,
                    Name = "Settings",
                    Breadcrump = "Dashboard / Settings",
                    RouterLink = "/dashboard/settings",
                    Icon = "fa fa-cog",
                    Visible = true
                },
                new Page
                {
                    Id = 7,
                    ParentId = 6,
                    Order = 0,
                    Name = "Menu",
                    Breadcrump = "Dashboard / Menu",
                    RouterLink = "/dashboard/settings/menu",
                    Visible = true
                },
                new Page
                {
                    Id = 8,
                    ParentId = 6,
                    Order = 1,
                    Name = "Page Permissions",
                    Breadcrump = "Dashboard / Page Permissions",
                    RouterLink = "/dashboard/settings/page-permissions",
                    Visible = true
                },
                new Page
                {
                    Id = 9,
                    ParentId = 6,
                    Order = 1,
                    Name = "General",
                    Breadcrump = "Dashboard / General",
                    RouterLink = "/dashboard/settings/general-settings",
                    Visible = true
                },
                new Page
                {
                    Id = 10,
                    ParentId = 1,
                    Order = 20,
                    Name = "Posts",
                    Breadcrump = "Dashboard / Posts",
                    RouterLink = "/dashboard/posts",
                    Icon = "fa fa-pencil-square",
                    Visible = true
                },
                new Page
                {
                    Id = 11,
                    ParentId = 10,
                    Order = 0,
                    Name = "All Posts",
                    Breadcrump = "Dashboard / Posts / All Posts",
                    RouterLink = "/dashboard/posts/all-posts",
                    Visible = true
                },
                new Page
                {
                    Id = 12,
                    ParentId = 10,
                    Order = 1,
                    Name = "New Post",
                    Breadcrump = "Dashboard / Posts / New Post",
                    RouterLink = "/dashboard/posts/new-post",
                    Visible = true
                },
                new Page
                {
                    Id = 13,
                    ParentId = 1,
                    Order = 25,
                    Name = "Projects",
                    Breadcrump = "Dashboard / Projects",
                    RouterLink = "/dashboard/projects",
                    Icon = "fa fa-briefcase",
                    Visible = true
                },
                new Page
                {
                    Id = 14,
                    ParentId = 13,
                    Order = 0,
                    Name = "All Projects",
                    Breadcrump = "Dashboard / Projects / All Projects",
                    RouterLink = "/dashboard/projects/all-projects",
                    Visible = true
                },
                new Page
                {
                    Id = 15,
                    ParentId = 13,
                    Order = 1,
                    Name = "New Project",
                    Breadcrump = "Dashboard / Projects / New Project",
                    RouterLink = "/dashboard/projects/new-project",
                    Visible = true
                },
                new Page
                {
                    Id = 16,
                    ParentId = 1,
                    Order = 30,
                    Name = "Pages",
                    Breadcrump = "Dashboard / Pages",
                    RouterLink = "/dashboard/pages",
                    Icon = "fa fa-window-maximize",
                    Visible = true
                },
                new Page
                {
                    Id = 17,
                    ParentId = 16,
                    Order = 0,
                    Name = "All Pages",
                    Breadcrump = "Dashboard / Pages / All Pages",
                    RouterLink = "/dashboard/pages/all-pages",
                    Visible = true
                },
                new Page
                {
                    Id = 18,
                    ParentId = 16,
                    Order = 1,
                    Name = "New Page",
                    Breadcrump = "Dashboard / Pages /New Page",
                    RouterLink = "/dashboard/pages/new-page",
                    Visible = true
                },
                new Page
                {
                    Id = 19,
                    ParentId = null,
                    Order = 40,
                    Name = "Media",
                    Breadcrump = "Dashboard / Media",
                    RouterLink = "/dashboard/media",
                    Icon = "fa fa-picture-o",
                    Visible = true
                },
                new Page
                {
                    Id = 20,
                    ParentId = null,
                    Order = 45,
                    Name = "Comments",
                    Breadcrump = "Dashboard / Comments",
                    RouterLink = "/dashboard/comments",
                    Icon = "fa fa-comments",
                    Visible = true
                },
                new Page
                {
                    Id = 21,
                    ParentId = null,
                    Order = 60,
                    Name = "Categories",
                    Breadcrump = "Dashboard / Categories",
                    RouterLink = "/dashboard/categories",
                    Icon = "fa fa-list",
                    Visible = true
                },
                new Page
                {
                    Id = 22,
                    ParentId = null,
                    Order = 61,
                    Name = "Tags",
                    Breadcrump = "Dashboard / Tags",
                    RouterLink = "/dashboard/tags",
                    Icon = "fa fa-tags",
                    Visible = true
                },
            };

        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().HasData(Pages);
        }
    }
}