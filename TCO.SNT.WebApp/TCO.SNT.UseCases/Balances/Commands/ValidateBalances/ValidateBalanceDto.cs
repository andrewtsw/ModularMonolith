namespace TCO.SNT.UseCases.Balances.Commands.ValidateBalances
{
    public class ValidateBalanceDto
    {
        public bool LastBlock { get; set; }

        public int CurrPage { get; set; }

        public int RsCount { get; set; }

        public BalanceDto[] Rows { get; set; }
    }
}
