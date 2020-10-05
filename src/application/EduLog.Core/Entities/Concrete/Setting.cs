namespace EduLog.Core.Entities.Concrete
{
    /// <summary>
    /// Sistem üzerinde tanımlanmış olan tüm temel ayarlar
    /// </summary>
    public enum Settings
    {
        /// <summary>
        /// Sayfada Head tagları arasında yer alacak başlık bilgisidir
        /// </summary>
        Title,

        /// <summary>
        /// Sayfada yer alan Head tagları arasında yer alan açıklama alanıdır
        /// </summary>
        Description,

        /// <summary>
        /// Sayfada footer ve header alanların gösterilecek email bilgisidir
        /// </summary>
        Email,

        /// <summary>
        /// Sistem maillerinin gönderileceği mail adresidir
        /// </summary>
        SystemEmail
    }

    /// <summary>
    /// It is the table where all system settings are stored
    /// </summary>
    public class Setting : BaseEntity
    {
        /// <summary>
        /// Table key
        /// </summary>
        public Settings Id { get; set; }

        /// <summary>
        /// Stored value
        /// </summary>
        public string Value { get; set; }
    }
}