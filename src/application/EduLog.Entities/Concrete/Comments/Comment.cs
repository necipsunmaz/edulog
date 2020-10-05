using EduLog.Core.Entities.Concrete;
using EduLog.Entities.Concrete.Posts;

namespace EduLog.Entities.Concrete.Comments
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}