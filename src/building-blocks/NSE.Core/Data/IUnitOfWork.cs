namespace NSE.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
