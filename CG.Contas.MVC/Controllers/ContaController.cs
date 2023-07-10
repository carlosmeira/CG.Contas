using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CG.Contas.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace CG.Contas.MVC.Controllers
{
    public class ContaController : Controller
    {
        private readonly ILogger<ContaController> _logger;

        private readonly string baseUrl = "http://localhost:5075/api/";

        public ContaController(ILogger<ContaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.GetAsync("conta");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    ViewData.Model = JsonConvert.DeserializeObject<List<ContaViewModel>>(data);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContaViewModel conta)
        {
            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.PostAsJsonAsync<ContaViewModel>("conta", conta);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ContaViewModel conta = new ContaViewModel();
            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.GetAsync("conta/"+id);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    conta = JsonConvert.DeserializeObject<ContaViewModel>(data);
                    return View(conta);
                } else {
                    return Error();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContaViewModel conta)
        {
            string data = JsonConvert.SerializeObject(conta);
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");

            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                //_client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.PutAsync("conta/"+conta.Id, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            ContaViewModel conta = new ContaViewModel();
            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.GetAsync("conta/"+id);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    conta = JsonConvert.DeserializeObject<ContaViewModel>(data);
                    return View(conta);
                } else {
                    return Error();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            using (var _client = new HttpClient()) {
                _client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await _client.DeleteAsync("conta/"+id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}