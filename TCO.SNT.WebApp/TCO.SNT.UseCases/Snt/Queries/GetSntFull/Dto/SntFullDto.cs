using System;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntFull
{
    public class SntFullDto : SntBaseDto
    {
        /// <summary>
        /// Регистрационный номер СНТ
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Дата оформления / регистрации СНТ
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        public SntProductFullDto[] Products { get; set; }

        /// <summary>
        /// Нефтепродукты
        /// </summary>
        public SntOilProductDto[] OilProducts { get; set; }
    }
}
