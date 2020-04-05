using Microsoft.Extensions.Configuration;
using IConfigurationProvider = webBeta.NSerializer.Base.IConfigurationProvider;

namespace webBeta.NSerializer.AspNetCore
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool GetBoolean(string key, bool defaultValue)
        {
            var conf = _configuration.GetValue<bool?>(key);
            return conf ?? defaultValue;
        }

        public string GetString(string key, string defaultValue)
        {
            var conf = _configuration.GetValue<string>(key);
            return conf ?? defaultValue;
        }
    }
}