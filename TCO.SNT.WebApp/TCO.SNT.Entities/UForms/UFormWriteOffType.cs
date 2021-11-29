namespace TCO.SNT.Entities
{
    /// <summary>
    /// Тип для поля Причина списания формы "Списание"
    /// </summary>
    public enum UFormWriteOffType
    {
        /// <summary>
        /// Производство
        /// </summary>
        MANUFACTURE,

        /// <summary>
        /// Реализовано в розничной торговле по чекам ККМ
        /// </summary>
        SOLD_IN_RETAIL_OR_COUPONS,

        /// <summary>
        /// Порча/утрата
        /// </summary>
        DAMAGE,

        /// <summary>
        /// Утилизация
        /// </summary>
        RECYCLING,

        /// <summary>
        /// Рекламация
        /// </summary>
        RECLAMATION,

        /// <summary>
        /// Утеря
        /// </summary>
        LOSS,

        /// <summary>
        /// Товар с данным кодом ТНВЭД не подлежит ведению в модуле "Виртуальный склад"
        /// </summary>
        IS_NOT_VSTORE,

        /// <summary>
        /// На медицинские нужды
        /// </summary>
        MEDICAL_NEEDS,

        /// <summary>
        /// На технические нужды
        /// </summary>
        TECHNICAL_NEEDS,

        /// <summary>
        /// Естественная убыль в пределах норм
        /// </summary>
        NATURAL_DECREASE_IN_NORM,

        /// <summary>
        /// Естественная убыль сверх норм
        /// </summary>
        NATURAL_DECREASE_OVER_NORM,

        /// <summary>
        /// Хищение
        /// </summary>
        THEFT,

        /// <summary>
        /// Списание за счёт виновного лица
        /// </summary>
        WRITE_OFF_BY_GUILTY,

        /// <summary>
        /// Списание на гарантированный социальный пакет
        /// </summary>
        SOCIAL_PACKAGE,

        /// <summary>
        /// Отсутствует требование по оформлению следующего СНТ
        /// </summary>
        NO_REQUIREMENTS_FOR_SNT,

        /// <summary>
        /// Переработка давальческого сырья
        /// </summary>
        CONVERSION,

        /// <summary>
        /// Услуга, работа
        /// </summary>
        SERVICE,

        /// <summary>
        /// Товар введен ошибочно
        /// </summary>
        MISTAKE,

        /// <summary>
        /// Учет ОС/ФА
        /// </summary>
        ACCOUNTING_FIXED_ASSETS,

        /// <summary>
        /// Прочее
        /// </summary>
        OTHER,

        /// <summary>
        /// Реализовано по талонам или картам по всем видам оплат
        /// </summary>
        COUPONS_OR_CARDS_PAYMENTS
    }
}
