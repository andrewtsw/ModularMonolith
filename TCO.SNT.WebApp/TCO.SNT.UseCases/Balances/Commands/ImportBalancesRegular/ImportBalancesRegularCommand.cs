using MediatR;
using System;

namespace TCO.SNT.UseCases.Balances.Commands.ImportBalancesRegular
{
    public class ImportBalancesRegularCommand : IRequest<ImportBalancesRegularResultDto>
    {
        public Guid? UserId { get; set; }

        public bool ProcessUndistributedStore { get; set; }
    }
}
