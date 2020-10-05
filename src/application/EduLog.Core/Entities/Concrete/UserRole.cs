using System.ComponentModel.DataAnnotations;

namespace EduLog.Core.Entities.Concrete
{
    public enum UserRoles
    {
        Admin = 1,
        Editor,
        Member
    }

    public class UserRole : BaseEntity
    {
        /// <summary>
        /// Table key
        /// </summary>
        public UserRoles Id { get; set; }

        /// <summary>
        /// User role name
        /// </summary>
        [Required, MaxLength(48)]
        public string Name { get; set; }
    }
}