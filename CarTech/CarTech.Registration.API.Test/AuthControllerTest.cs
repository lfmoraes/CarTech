using CarTech.Registration.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace CarTech.Registration.API.Test
{
    public class AuthControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient _client { get; }

        public AuthControllerTest(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }
    }
}
