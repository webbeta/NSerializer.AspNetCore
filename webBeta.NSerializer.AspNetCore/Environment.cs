using Microsoft.Extensions.Hosting;
using webBeta.NSerializer.Base;

namespace webBeta.NSerializer.AspNetCore
{
    public class Environment : IEnvironment
    {
        private readonly IHostEnvironment _hostEnvironment;

        public Environment(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public bool IsProd()
        {
            return _hostEnvironment.IsProduction();
        }
    }
}