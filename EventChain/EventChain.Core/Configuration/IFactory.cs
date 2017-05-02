using System.Collections.Generic;

namespace EventChain.Core.Configuration
{
    public interface IFactory<out T>
    {
        IEnumerable<string> SupportedTypeValues { get; }
        IEnumerable<T> Build(string name);
        IEnumerable<T> Build();
    }
}