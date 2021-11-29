namespace TCO.SNT.UseCases.Snt.Shared
{
    /// <summary>
    /// Данные о грузе, перевозимом на автомобильном транспорте (K)
    /// </summary>
    public class SntCarCargoInfoDto
    {
        /// <summary>
        /// Ф.И.О. водителя
        /// </summary>
        public string DriverFio { get; set; }

        /// <summary>
        /// ИИН водителя
        /// </summary>
        public string DriverTin { get; set; }

        /// <summary>
        /// Номер оттиска пломбы
        /// </summary>
        public string StampPrintNumber { get; set; }
    }
}
