using EduLog.Core.Utilities.Attributes;
using System;

namespace EduLog.Core.Entities.Concrete
{
    /// <summary>
    /// Veri işlem durumlarının enum degerleridir
    /// </summary>
    public enum DataStatus
    {
        /// <summary>
        /// Verinin silinme durumudur.
        /// </summary>
        Deleted = 1,

        /// <summary>
        /// Verinin aktiflik durumudur.
        /// </summary>
        Activated,

        /// <summary>
        /// Verinin pasiflik durumudur.
        /// </summary>
        DeActivated
    }

    /// <summary>
    /// Temel loglamaların kalıtım olarak aktarılmasını sağlar
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Kaydı oluşturan kişi tekil bilgisi
        /// </summary>
        public int CreatedById { get; set; }

        /// <summary>
        /// Kaydı son güncelleyen kişi tekil bilgisi
        /// </summary>
        public int? ModifiedById { get; set; }

        /// <summary>
        /// Kaydın aktiflik, pasiflik ve dilinme durumlarının tutulduğu alandır.
        /// </summary>
        [Index]
        public DataStatus DataStatus { get; set; }

        /// <summary>
        /// Kaydın oluşturulma tarihidir
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Kaydın güncellenme tarihidir
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Kaydı oluşturan kişi bilgileri
        /// </summary>
        public User CreatedBy { get; set; }

        /// <summary>
        /// Kaydı son güncelleyen kişi bilgileri
        /// </summary>
        public User ModifiedBy { get; set; }
    }
}