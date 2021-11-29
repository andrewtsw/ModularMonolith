using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.UseCases.Snt.Queries.GetSntList;

namespace TCO.SNT.Contract
{
    public interface ISntModuleContract
    {
        Task<SntListResponseDto> GetSntList(SntListRequestDto dto, CancellationToken cancellationToken);
    }
}
