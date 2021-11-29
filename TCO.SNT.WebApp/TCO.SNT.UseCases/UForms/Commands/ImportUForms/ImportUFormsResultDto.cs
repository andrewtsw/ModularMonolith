namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    public class ImportUFormsResultDto
    {
        public int Added { get; set; }

        public int Updated { get; set; }

        public static ImportUFormsResultDto Empty() => new ImportUFormsResultDto { Added = 0, Updated = 0 };
    }
}
