using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarTech.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace CarTech.App.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IToastNotification _toastNotification;

        public CategoriaController(
            IHttpClientFactory httpClient,
            IToastNotification toastNotification)
        {
            _httpClient = httpClient;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index()
        //{
        //    var client = _httpClient.CreateClient("cartech");
        //    var response = await client.GetAsync("categorias");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var categorias = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(await response.Content.ReadAsStringAsync());
        //        return View(categorias);
        //    }
        //    else
        //    {
        //        if (response.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            _toastNotification.AddErrorToastMessage("Acesso Negado!");
        //        }
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        public IActionResult Create()
        {
            CategoriaViewModel model = new CategoriaViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaViewModel model)
        {
            bool result = false;
            var client = _httpClient.CreateClient("cartech");

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync("categorias", content);

            if(response.IsSuccessStatusCode)
            {
                result = true;
            }

            return Json(new { Success = result });
        }
    }
}
