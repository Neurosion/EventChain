using System.IO;
using Newtonsoft.Json;
using EventChain.Core.Extensions;

namespace EventChain.Core.Configuration
{
    public class JsonConfigurationReader : IConfigurationReader
    {
        public T Read<T>(string path)
        {
            path.ThrowIfNullOrWhiteSpace(nameof(path))
                .ThrowIf<FileNotFoundException, string>(!File.Exists(path), $"No file found at '{path}'");

            var rawConfiguration = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<T>(rawConfiguration);

            return config;
        }
    }
}