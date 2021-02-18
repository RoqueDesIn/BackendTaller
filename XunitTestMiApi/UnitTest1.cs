using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using XunitTestMiApi;

namespace XUnitTestMiApi
{
    public class LoginTests : IClassFixture<TestFixture<MiApi.Startup>>
    {
        private HttpClient Client;

        public LoginTests(TestFixture<MiApi.Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task LoginTests_LoginCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "pepe",
                    Password = "pepe"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "true");
        }

        [Fact]
        public async Task LoginTests_LoginIncorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "jose",
                    Password = "lolete"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

    }
}