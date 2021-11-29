namespace TCO.SNT.Entities
{
    /// <summary>
    /// Данные о грузе, перевозимом на автомобильном транспорте (K)
    /// </summary>
    public class SntCarCargoInfo
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

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
