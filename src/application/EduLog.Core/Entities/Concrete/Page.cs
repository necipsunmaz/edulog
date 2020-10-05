using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduLog.Core.Entities.Concrete
{
    public class Page : BaseEntity
    {
        /// <summary>
        /// It's table key column but not auto increment
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Parent page key value
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Page order
        /// </summary>
        public short Order { get; set; }

        /// <summary>
        /// Page definition name
        /// </summary>
        [Required, MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Breadcrump { get; set; }

        [MaxLength(128)]
        public string RouterLink { get; set; }

        [MaxLength(32)]
        public string Icon { get; set; }

        /// <summary>
        /// This value change page visible status on the dashboard menu
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Foreignkey parent page
        /// </summary>
        public Page Parent { get; set; }
    }
}