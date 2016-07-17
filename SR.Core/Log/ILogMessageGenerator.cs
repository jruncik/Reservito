namespace SR.Core.Log
{
    public interface ILogMessageGenerator
    {
        string GenerateMessag(LogLevel level, object sender, string message);
    }
}