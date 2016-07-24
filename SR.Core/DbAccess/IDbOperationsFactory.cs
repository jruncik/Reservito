namespace SR.Core.DbAccess
{
    public interface IDbOperationsFactory
    {
        IDbOperations CreateDbOperations();
    }
}
