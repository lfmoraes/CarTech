using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CarTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NToastNotify;

namespace CarTech.App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IToastNotification _toastNotification;

        public ClienteController( 
            IHttpClientFactory httpClient, 
            IToastNotification toastNotification)
        {
            _httpClient = httpClient;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient("cartech");
            var response = await client.GetAsync("clientes");

            if (response.IsSuccessStatusCode)
            {
                var clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(await response.Content.ReadAsStringAsync());
                return View(clientes);
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _toastNotification.AddErrorToastMessage("Acesso Negado!");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
