namespace TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsRegular
{
    public class ImportAwpsResultDto
    {
        public int Added { get; set; }

        public int Updated { get; set; }

        public static ImportAwpsResultDto Empty() => new ImportAwpsResultDto { Added = 0, Updated = 0 };
    }
}
