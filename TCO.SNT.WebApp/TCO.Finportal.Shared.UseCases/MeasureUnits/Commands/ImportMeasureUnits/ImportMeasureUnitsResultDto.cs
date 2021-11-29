namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Commands.ImportMeasureUnits
{
    public class ImportMeasureUnitsResultDto
    {
        public int Added { get; set; }

        public int Updated { get; set; }

        public static ImportMeasureUnitsResultDto Empty() => new ImportMeasureUnitsResultDto { Added = 0, Updated = 0 };
    }
}
