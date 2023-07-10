using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CG.Contas.API.Models;
using CG.Contas.API.Services.ContaService;

namespace CG.Contas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;
        public ContaController(IContaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            //if (result.Count == 0) return new List<Conta>();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            if (result is null) return NotFound("Conta Inexistente.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Conta conta)
        {
            var result = await _service.Add(conta);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, Conta conta)
        {
            var result = await _service.Update(id, conta);
            if (result is null) return NotFound("Conta Inexistente.");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            if (result is null) return NotFound("Conta Inexistente.");
            return Ok(result);
        }

    }
}