namespace SR.Core
{
    public interface IDbStorable
    {
        void Save();

        void Load();

        void Delete();

        object GetDbObject();
    }
}