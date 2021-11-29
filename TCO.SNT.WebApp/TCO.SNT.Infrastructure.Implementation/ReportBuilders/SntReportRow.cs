namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders
{
    public class SntReportRow
    {
        /// <summary>
        /// Регистрационный номер СНТ
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Номер СНТ из учетной системы
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата оформления СНТ
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Срок СНТ/ Deadline
        /// </summary>
        public string Deadline { get; set; }

        /// <summary>
        /// БИН отправителя
        /// </summary>
        public string SenderTin { get; set; }

        /// <summary>
        /// БИН получателя
        /// </summary>
        public string RecipientTin { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Тип Снт
        /// </summary>
        public string SntType { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// Склад
        /// </summary>
        public string TaxpareStoreName { get; set; }

        /// <summary>
        /// Id Склада
        /// </summary>
        public int TaxpareStoreId { get; set; }

        /// <summary>
        /// Номер контракта
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// Условия поставки (ИНКОТЕРМС) (F 45.1)
        /// </summary>
        public string DeliveryCondition { get; set; }

        /// <summary>
        /// Код страны отправки/отгрузки (B 19)
        /// </summary>
        public string SenderCountryCode { get; set; }

        /// <summary>
        /// Адрес отправки
        /// </summary>
        public string SenderActualAddress { get; set; }

        /// <summary>
        /// Код страны Код страны доставки/поставки (C 28)
        /// </summary>
        public string RecepientCountryCode { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string RecepientActualAddress { get; set; }

        /// <summary>
        /// Дата потверждения ОГД
        /// </summary>
        public string OgdApproveDate { get; set; }

        /// <summary>
        /// Дата потверждения TCO
        /// </summary>
        public string TcoApproveDate { get; set; }

        /// <summary>
        /// Наименование товара (G1 3)
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Цена за единицу товара (G1 7)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество (объем) (G1 6)
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Total { get; set; }
    }
}
