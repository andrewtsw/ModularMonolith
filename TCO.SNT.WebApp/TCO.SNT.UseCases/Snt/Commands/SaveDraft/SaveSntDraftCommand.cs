using MediatR;

namespace TCO.SNT.UseCases.Snt.Commands.SaveDraft
{
    public class SaveSntDraftCommand : IRequest<int>
    {
        public SaveSntDraftCommand(SntDraftDto snt)
        {
            Snt = snt;
        }

        public SntDraftDto Snt { get; }
    }
}
