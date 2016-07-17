namespace TV.Core.Rights
{
    public interface IRights
    {
        bool IsInRole(string role);

        bool IsInRole(Roles roles);
    }
}