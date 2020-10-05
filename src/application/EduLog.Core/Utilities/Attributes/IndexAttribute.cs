using System;

namespace EduLog.Core.Utilities.Attributes
{
    /// <summary>
    /// Veritabanı modellerine Index atama yeteğenini kazandırır
    /// Detaylı bilgi için: https://www.google.com/search?q=Database+Index+nedir&oq=Database+Index+nedir
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IndexAttribute : Attribute
    {
        /// <summary>
        /// Oluşturulan Index'in tabloda tekil olmasını sağlar
        /// </summary>
        public bool IsUnique { get; set; }
    }
}