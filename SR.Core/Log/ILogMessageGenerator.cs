namespace TV.Core.Log
{
    public interface ILogMessageGenerator
    {
        string GenerateMessag(LogLevel level, object sender, string message);
    }
}