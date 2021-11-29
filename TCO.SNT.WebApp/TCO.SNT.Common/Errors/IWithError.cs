namespace TCO.SNT.Common.Errors
{
    public interface IWithError
    {
        string ErrorCode { get; }

        void SetErrorDescription(string description);
    }
}
