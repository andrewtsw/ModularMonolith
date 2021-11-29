using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// АВР
    /// </summary>
    public class Awp
    {
        public const int RegistrationNumberMaxLength = 50;
        public const int NumberMaxLength = 50;
        public const int TinMaxLength = 30;

        public int Id { get; protected set; }

        /// <summary>
        /// Регистрационный номер АВР
        /// </summary>
        [MaxLength(RegistrationNumberMaxLength)]
        [Required]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Номер АВР из учетной системы
        /// </summary>
        [MaxLength(NumberMaxLength)]
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Дата выписки АВР
        /// </summary>
        public DateTime? AwpDate { get; set; }

        /// <summary>
        /// Дата подписания (принятия) работ (услуг)
        /// </summary>
        public DateTime? AwpSignDate { get; set; }

        /// <summary>
        /// ИИН/БИН отправителя
        /// </summary>
        [MaxLength(TinMaxLength)]
        public string SenderTin { get; set; }

        /// <summary>
        /// ИИН/БИН получателя
        /// </summary>
        [MaxLength(TinMaxLength)]
        public string RecipientTin { get; set; }
        
        /// <summary>
        /// Статус АВР
        /// </summary>
        public AwpStatus Status { get; set; }

        public long ExternalId { get; set; }

        public static Awp CreateNew(long externalId)
        {
            return new Awp
            {
                ExternalId = externalId                
            };
        }
    }
}
