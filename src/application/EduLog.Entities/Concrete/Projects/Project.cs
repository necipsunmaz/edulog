using EduLog.Core.Entities.Concrete;
using System;

namespace EduLog.Entities.Concrete.Projects
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public int? ThumbnailId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Media.Media Thumbnail { get; set; }
    }
}