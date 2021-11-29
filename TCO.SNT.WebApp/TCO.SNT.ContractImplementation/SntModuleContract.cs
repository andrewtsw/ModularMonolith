using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Contract;
using TCO.SNT.UseCases.Snt.Queries.GetSntList;

namespace TCO.SNT.ContractImplementation
{
    internal class SntModuleContract : ISntModuleContract
    {
        private readonly ISender _sender;

        public SntModuleContract(ISender sender)
        {
            _sender = sender;
        }

        public Task<SntListResponseDto> GetSntList(SntListRequestDto dto, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetSntListQuery(dto), cancellationToken);
        }
    }
}
