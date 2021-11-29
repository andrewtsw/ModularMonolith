using System;

namespace TCO.Finportal.Shared.Entities
{
    public class SharedSettings
    {
        public static readonly DateTime MinDate = new DateTime(2019, 1, 1);

        public int Id { get; set; }

        public DateTimeOffset MeasureUnitsLastEventDateUtc { get; set; }
    }
}
