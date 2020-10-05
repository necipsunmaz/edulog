using EduLog.Entities.Concrete.Tags;

namespace EduLog.Entities.Concrete.Posts
{
    /// <summary>
    /// Yazıya atanmış olan tüm etiketlerin eşleştirmelerinin tutulduğu tablodur
    /// </summary>
    public class PostTag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}