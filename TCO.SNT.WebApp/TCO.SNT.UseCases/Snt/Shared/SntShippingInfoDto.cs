using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Snt.Shared
{
    public class SntShippingInfoDto
    {
        /// <summary>
        /// Наименование перевозчика (E 37)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Нерезидент (E 37.1)
        /// </summary>
        public bool NonResident { get; set; }

        /// <summary>
        /// ИИН/БИН (E 38)
        /// </summary>
        public string Tin { get; set; }

        /// <summary>
        /// Вид транспорта (E 39.1)
        /// </summary>
        public SntTransporterTransportType[] TransportTypes { get; set; }

        /// <summary>
        /// Гос. номер АТС (39.1 а1.1)
        /// </summary>
        public string CarStateNumber { get; set; }

        /// <summary>
        /// Гос. номер прицепа (39.1 а2.1)
        /// </summary>
        public string TrailerStateNumber { get; set; }

        /// <summary>
        /// Номер вагона (39.1 b1)
        /// </summary>
        public string CarriageNumber { get; set; }

        /// <summary>
        /// Номер борта (39.1 с1)
        /// </summary>
        public string BoardNumber { get; set; }

        /// <summary>
        /// Номер судна (39.1 d1)
        /// </summary>
        public string ShipNumber { get; set; }
    }
}
