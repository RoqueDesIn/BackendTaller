using System;
using System.Collections.Generic;
using System.Text;

namespace XunitTestMiApi
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using MiApi;
    using MiCore.DTO;
    using Xunit;
    using XUnitTestMiApi;

    namespace MiApiTest
    {
        public class Resum_test : IClassFixture<TestFixture<Startup>>
        {
            private HttpClient Client;
            public Resum_test(TestFixture<Startup> fixture)
            {
                Client = fixture.Client;
            }
            [Fact]
            public async Task SizeRsumTotal()
            {
                // Arrange
                var request = new
                {
                    Url = "/Resum",
                };
                // Act
                var response = await Client.GetAsync(request.Url);
                var value = await response.Content.ReadAsStringAsync();
                var listaPersonas = JsonSerializer.Deserialize<List<ResumTotal>>(value);
                // Assert
                response.EnsureSuccessStatusCode();
                Assert.True(listaPersonas.Count == 1);
            }
            [Fact]
            public async Task SizeRsumUser()
            {
                // Arrange
                var request = new
                {
                    Url = "/Resum/UserResum",
                    Body = new
                    {
                    }
                };
                // Act
                var response = await Client.GetAsync(request.Url);
                var value = await response.Content.ReadAsStringAsync();
                var listaPersonas = JsonSerializer.Deserialize<List<ResumUser>>(value);
                // Assert
                response.EnsureSuccessStatusCode();
                Assert.True(listaPersonas.Count > 1);


            }
        }
    }
}
