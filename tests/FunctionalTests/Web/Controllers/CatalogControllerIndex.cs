﻿using System.Net.Http;
using System.Threading.Tasks;
using OnlineShop.Web;
using Xunit;

namespace OnlineShop.FunctionalTests.Web.Controllers
{
    public class CatalogControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public CatalogControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsHomePageWithProductListing()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains(".NET Bot Black Sweatshirt", stringResponse);
        }
    }
}
