using EduLog.Core.Entities.Concrete;

namespace EduLog.Entities.Concrete.Projects
{
    public class ProjectLink : BaseEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ExternalLink { get; set; }
        public Project Project { get; set; }
    }
}