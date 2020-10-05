using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace EduLog.Core.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IHostingEnvironment"/>.
    /// </summary>
    public static class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Projenin bir üst patinde tutulan statik klasörünü ana path olarak geri döndürür. (Docs)
        /// </summary>
        public static string ContentRootPath(this IHostingEnvironment env) => env.ContentRootPath.Replace(env
                                                 .ContentRootPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }).Last(),
                                                 "Documents");

        /// <summary>
        /// Görsellerin tutulduğu klasör yoludur
        /// </summary>
        public static string ContentImagePath(this IHostingEnvironment env) => $"{env.ContentRootPath()}/images";

        /// <summary>
        /// Sistem başlangıcında ana içerik klasörlerini oluşturur
        /// </summary>
        public static void CreateContentFolders(this IHostingEnvironment env)
        {
            if (!Directory.Exists(env.ContentImagePath()))
            {
                Directory.CreateDirectory(env.ContentImagePath());
            }
        }
    }
}