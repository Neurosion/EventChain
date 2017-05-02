namespace EventChain.Core.Configuration
{
    public interface ICompositeConfiguration : IConfiguration
    {
        string Name { get; set; }
    }
}