using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarTech.App.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public UserController(ILogger<UserController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            var client = _httpClient.CreateClient("cartech");
           // string result 

            return View();
        }
    }
}
