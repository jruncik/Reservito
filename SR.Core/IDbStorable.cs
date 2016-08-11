namespace SR.Core
{
    public interface IDbStorable
    {
        void Save();

        void Load();

        void Delete();

        T GetDbObject<T>() where T : class;
    }
}