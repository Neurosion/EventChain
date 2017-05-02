namespace EventChain.Core.Configuration
{
    public interface IConfigurationReader
    {
        T Read<T>(string path);
    }
}