using MediatR;
using EsfApiSdk.Snt;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    public class ChangeSntStatusCommand : IRequest<SntSimpleDto>
    {
        public ChangeSntStatusCommand(ChangeSntStatusDto dto, SntActionType actionType)
        {
            ChangeSntStatusDto = dto;
            ActionType = actionType;
        }

        public ChangeSntStatusDto ChangeSntStatusDto { get; }

        public SntActionType ActionType { get; set; }
    }
}
