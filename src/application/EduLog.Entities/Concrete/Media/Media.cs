using EduLog.Core.Entities.Concrete;

namespace EduLog.Entities.Concrete.Media
{
    public class Media : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Detail { get; set; }
    }
}