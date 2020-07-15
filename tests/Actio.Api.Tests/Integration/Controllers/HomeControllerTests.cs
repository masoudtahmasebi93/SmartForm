using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Smartform.Api.Tests.Integration.Controllers
{
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        private readonly TestServer _server;
        private readonly HttpClient _client;

        [Fact]
        public async Task home_controller_get_should_return_string_content()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            content.Should().BeEquivalentTo("Hello from Actio API!");
        }
    }
}