﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using OnlineShop.Web;
using Xunit;

namespace OnlineShop.FunctionalTests.Web.Controllers
{
    public class OrderIndexOnGet : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public OrderIndexOnGet(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsRedirectGivenAnonymousUser()
        {
            var response = await Client.GetAsync("/Order/Index");
            var redirectLocation = response.Headers.Location.OriginalString;

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("Account/Signin", redirectLocation);
        }
    }
}
