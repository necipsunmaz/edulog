using EduLog.Core.Utilities.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduLog.Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Table key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        [Index]
        public UserRoles UserRoleId { get; set; }

        /// <summary>
        /// Logined user name
        /// </summary>
        [Required, MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Logined user surname
        /// </summary>
        [Required, MaxLength(64)]
        public string Surname { get; set; }

        /// <summary>
        /// Idendity mail adress for login
        /// </summary>
        [Required, MaxLength(48)]
        public string Email { get; set; }

        /// <summary>
        /// User ten character phone number
        /// </summary>
        [MaxLength(10)]
        public string Phone { get; set; }

        /// <summary>
        /// User hashed password
        /// </summary>
        [MaxLength(48)]
        public string Password { get; set; }

        /// <summary>
        /// Create foreignkey UserRole table
        /// </summary>
        public UserRole UserRole { get; set; }
    }
}