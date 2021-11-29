using MediatR;

namespace TCO.SNT.UseCases.Balances.Commands.FixBalancesImportKey
{
    /// <summary>
    /// This fix should be removed after single run on production
    /// </summary>
    public class FixBalancesImportKeyCommand : IRequest<FixBalancesImportKeyResultDto>
    {
    }
}
