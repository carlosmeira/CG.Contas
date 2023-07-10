using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CG.Contas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViacepController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string cep)
        {
            var baseUrl = "http://viacep.com.br/ws/";

            var options = new RestClientOptions(baseUrl);
            
            var client = new RestClient(options);
            var request = new RestRequest(cep+"/json");
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
                return Ok(response.Content);
            else
                return NotFound();
        }
    }
}