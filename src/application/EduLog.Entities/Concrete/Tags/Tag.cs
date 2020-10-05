using EduLog.Core.Entities.Concrete;

namespace EduLog.Entities.Concrete.Tags
{
    public class Tag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}