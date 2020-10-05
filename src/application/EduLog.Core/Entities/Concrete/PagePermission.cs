namespace EduLog.Core.Entities.Concrete
{
    /// <summary>
    /// Yönetim panelinde sayfaların kullanıcı rollerine göre
    /// yetkilendirmelerinin saklandığı tablodur
    /// </summary>
    public class PagePermission : BaseEntity
    {
        public int Id { get; set; }
        public UserRoles UserRoleId { get; set; }
        public int PageId { get; set; }
        public UserRole UserRole { get; set; }
        public Page Page { get; set; }
    }
}