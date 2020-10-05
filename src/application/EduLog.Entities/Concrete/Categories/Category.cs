using EduLog.Core.Entities.Concrete;

namespace EduLog.Entities.Concrete.Categories
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Detail { get; set; }
    }
}