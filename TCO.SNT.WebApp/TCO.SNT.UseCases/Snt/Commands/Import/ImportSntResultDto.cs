namespace TCO.SNT.UseCases.Snt.Commands.Import
{
    public class ImportSntResultDto
    {
        public int Added { get; set; }

        public int Updated { get; set; }

        public static ImportSntResultDto Empty() => new ImportSntResultDto { Added = 0, Updated = 0 };
    }
}
