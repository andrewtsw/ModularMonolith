namespace TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular
{
    public class ImportBalancesRegularResultDto
    {
        public int Added { get; set; }

        public int UpdatedAndDeactivated { get; set; }

        public int NotChanged { get; set; }
    }
}
