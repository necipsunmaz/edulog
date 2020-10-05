using EduLog.Core.Entities.Concrete;
using System.Collections.Generic;

namespace EduLog.Entities.Concrete.Posts
{
    /// <summary>
    /// Yazının mevcut durumlarıdır
    /// </summary>
    public enum PostStatuses
    {
        Private = 1,
        Public
    }

    /// <summary>
    /// Yazıların sayfa veya makale olarak ayrılmasını sağlar
    /// </summary>
    public enum PostTypes
    {
        Article = 1,
        Page
    }

    public class Post : BaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? ThumbnailId { get; set; }
        public PostStatuses PostStatusId { get; set; }
        public PostTypes PostTypeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public Media.Media Thumbnail { get; set; }

        /// <summary>
        /// Yazıya atanmış olan tüm etiketleri döndürür
        /// </summary>
        public ICollection<PostTag> Tags { get; set; }
    }
}