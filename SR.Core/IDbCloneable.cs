namespace SR.Core
{
    public interface IDbCloneable
    {
        T Clone<T>() where T : class;
    }
}
