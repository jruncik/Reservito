namespace SR.Core
{
    public interface IDbStorable
    {
        void Save();
        void Reload();
        void Delete();
    }
}