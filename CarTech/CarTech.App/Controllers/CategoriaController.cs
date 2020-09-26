using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient("cartech");
            var response = await client.GetAsync("categorias");

            if (response.IsSuccessStatusCode)
            {
                var categorias = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(await response.Content.ReadAsStringAsync());
                return View(categorias);
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

        public IActionResult Modal()
        {
            return PartialView();
        }

        public async Task<IActionResult> Create(int id)
        {
            CategoriaViewModel model = new CategoriaViewModel();

            if(id > 0)
            {
                using (var client = _httpClient.CreateClient("cartech"))
                {
                    var response = await client.GetAsync("categorias/" + id.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        model = JsonConvert.DeserializeObject<CategoriaViewModel>(await response.Content.ReadAsStringAsync());
                    }
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaViewModel model)
        {
            bool result = false;
            var message = string.Empty;

            var client = _httpClient.CreateClient("cartech");

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = new HttpResponseMessage();

            if (model.Id > 0)
            {
                response = await client.PutAsync("categorias/" + model.Id.ToString(), content);
                message = "Cadastro atualizado com sucesso!";
            }
            else
            {
                response = await client.PostAsync("categorias", content);
                message = "Cadastro realizado com sucesso!";
            }

            if (response.IsSuccessStatusCode)
            {
                result = true;
            }

            return Json(new { Success = result, Message = message });
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool success = false;

            try
            {
                var client = _httpClient.CreateClient("cartech");
                var response = await client.DeleteAsync("categorias/" + id.ToString());

                success = response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success });
        }
    }
}
