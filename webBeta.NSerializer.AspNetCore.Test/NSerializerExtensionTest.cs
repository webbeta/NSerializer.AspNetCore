using System.IO;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using webBeta.NSerializer.AspNetCore.Sample;
using Xunit;

namespace webBeta.NSerializer.AspNetCore.Test
{
    public class NSerializerExtensionTest
    {
        public NSerializerExtensionTest()
        {
            System.Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");

            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            var basePath = Path.Combine(
                currentDirectory.Parent?.Parent?.Parent?.ToString(),
                "webBeta.NSerializer.AspNetCore.Sample",
                "bin");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(basePath))
                .AddJsonFile("appsettings.json", false, true);

            IConfiguration configurationAppSettings = builder.Build();

            var ymlPath = Path.Combine(
                basePath,
                "Debug",
                "netcoreapp3.1",
                "conf",
                "serializer");

            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configurationAppSettings)
                .UseSetting("serializer:metadata:dir", ymlPath)
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        private readonly HttpClient _client;

        [Fact]
        public async void Test_Correct_Created_Response()
        {
            var response = await _client.GetAsync("/demo/ascreated");
            var content = await response.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo("{\"createdMessage\":\"Created message!\"}");
        }

        [Fact]
        public async void Test_Correct_Ok_Response()
        {
            var response = await _client.GetAsync("/demo/asok");
            var content = await response.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo("{\"okMessage\":\"Ok message!\"}");
        }
    }
}