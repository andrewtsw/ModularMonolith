namespace TCO.SNT.UseCases.Snt.Shared
{
    public class SntOilSetDto
    {
        /// <summary>
        /// Код ОГД адреса доставки/поставки (G7 72)
        /// </summary>
        public string KogdOfRecipient { get; set; }

        /// <summary>
        /// Код ОГД адреса отправки/отгрузки (G7 71)
        /// </summary>
        public string KogdOfSender { get; set; }

        /// <summary>
        /// Код операции (G7 69)
        /// </summary>
        public string OperationCode { get; set; }

        /// <summary>
        /// Тип поставщика (G7 70)
        /// </summary>
        public string ProductSellerType { get; set; }
    }
}
