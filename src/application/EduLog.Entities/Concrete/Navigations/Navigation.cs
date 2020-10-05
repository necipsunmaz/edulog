using EduLog.Core.Entities.Concrete;

namespace EduLog.Entities.Concrete.Navigations
{
    public class Navigation : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public short Order { get; set; }
    }
}