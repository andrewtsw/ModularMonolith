namespace TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces
{
    public interface IBackgroungJobService
    {
        void EnqueueImportBalances();
    }
}
